using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Pythagoras.Infrastructure.Realtime
{
    public sealed class Quartz
    {
        private readonly QuartzSettings _settings;
        private readonly ILogger<Quartz> _logger;
        private Thread? _thread;

        public event EventHandler<QuartzEventArgs>? ErrorOccurred;
        public event EventHandler? Starting;
        public event EventHandler? Stopped;
        public event EventHandler<QuartzEventArgs>? VirtualTimeChanged;
        public event EventHandler<QuartzEventArgs>? ClockTimeChanged;

        public bool IsRunning => _thread?.IsAlive ?? false;

        public Quartz(QuartzSettings settings, ILogger<Quartz> logger)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Start(CancellationToken cancellationToken)
        {
            if (!IsRunning)
            {
                _thread = new Thread(ThreadProc);
                _thread.Priority = ThreadPriority.Highest;
                _thread.Start(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Quartz already started");
            }
        }

        public bool Join(int millisecondsTimeout)
        {
            return _thread?.Join(millisecondsTimeout) ?? true;
        }

        private void ThreadProc(object? param)
        {
            try
            {
                var cancellationToken = (CancellationToken)param!;

                int prevDT = 0, prevT0 = 0;
                int virtualPeriod = 1000;
                DateTime prevVirtualTime = DateTime.MinValue;
                DateTime prevClockTime = DateTime.MinValue;

                var systemStartTime = DateTime.Now;
                var clockStartTime = new DateTime(
                    _settings.Date.Year, _settings.Date.Month, _settings.Date.Day,
                    _settings.StartTime.Hours, _settings.StartTime.Minutes, _settings.StartTime.Seconds);
                var clockTime = clockStartTime;

                _logger.LogInformation($"Quartz starting. ClockTime={clockTime:dd.MM.yy HH:mm:ss}, TimeFactor={_settings.TimeFactor}");
                Starting?.Invoke(this, EventArgs.Empty);
                
                var sw = new Stopwatch();
                sw.Start();

                while (clockTime.TimeOfDay <= _settings.EndTime && !cancellationToken.IsCancellationRequested)
                {
                    var t0 = sw.ElapsedMilliseconds;
                    var realT = t0 - prevT0;
                    prevT0 = (int)t0;

                    var systemTime = DateTime.Now;
                    var virtualTime = systemStartTime.AddMilliseconds(t0);
                    clockTime = clockStartTime.AddMilliseconds((virtualTime.TimeOfDay - systemStartTime.TimeOfDay).TotalMilliseconds * _settings.TimeFactor);
                    var DT = (int)(virtualTime - systemTime).TotalMilliseconds;

                    var newVirtTime = virtualTime.AddMilliseconds(-prevDT);
                    if (newVirtTime > virtualTime) virtualTime = newVirtTime;

                    var newClockTime = clockTime.AddMilliseconds(-prevDT * _settings.TimeFactor);
                    if (newClockTime > clockTime) clockTime = newClockTime;

                    _logger.LogDebug($"RealPeriod={realT}, SystemTime={systemTime:HH:mm:ss.fff}, VirtualTime={virtualTime:HH:mm:ss.fff}, ClockTime={clockTime:HH:mm:ss.fff}");

                    if ((virtualTime - prevVirtualTime).TotalMilliseconds >= virtualPeriod)
                    {
                        try
                        {
                            _logger.LogDebug("Invoke VirtualTimeChanged handler");
                            VirtualTimeChanged?.Invoke(this, new QuartzEventArgs { Time = virtualTime });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "An error occurred in the VirtualTimeChanged handler");
                        }
                        prevVirtualTime = virtualTime;
                    }

                    if (cancellationToken.IsCancellationRequested) break;

                    if ((clockTime - prevClockTime).TotalMilliseconds >= virtualPeriod)
                    {
                        try
                        {
                            _logger.LogDebug("Invoke ClockTimeChanged handler");
                            ClockTimeChanged?.Invoke(this, new QuartzEventArgs { Time = clockTime });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "An error occurred in the ClockTimeChanged handler");
                        }
                        prevClockTime = clockTime;
                    }

                    var t1 = sw.ElapsedMilliseconds;
                    var tJob = (int)(t1 - t0);
                    var tTimer = virtualPeriod - tJob;
                    prevDT = DT;

                    Thread.Sleep(tTimer);
                }

                _logger.LogInformation($"Quartz stopped. ClockTime={clockTime:dd.MM.yy HH:mm:ss}, IsCancellationRequested={cancellationToken.IsCancellationRequested}");
                Stopped?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Quartz stopped");
                try
                {
                    ErrorOccurred?.Invoke(this, new QuartzEventArgs { Message = ex.Message });
                }
                catch { }
            }
        }
    }
}
