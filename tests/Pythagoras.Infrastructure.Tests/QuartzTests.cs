using Microsoft.Extensions.Logging;
using Moq;
using Pythagoras.Infrastructure.Realtime;

namespace Pythagoras.Infrastructure.Tests
{
    public class QuartzTests
    {
        [Fact]
        public void QuartzStart_WithFactor_1()
        {
            var logger = new Mock<ILogger<Quartz>>().Object;
            var settings = new QuartzSettings
            {
                Date = DateTime.Now,
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(10, 00, 10),
                TimeFactor = 1.0
            };
            var lstVirt = new List<QuartzEventArgs>();
            var lstClock = new List<QuartzEventArgs>();
            var completedEvent = new AutoResetEvent(false);
            using var cts = new CancellationTokenSource();

            var quartz = new Quartz(settings, logger);
            quartz.ErrorOccurred += (s, args) => Assert.Fail("ErrorOccurred event caught");
            quartz.VirtualTimeChanged += (s, args) => lstVirt.Add(args);
            quartz.ClockTimeChanged += (s, args) => lstClock.Add(args);
            quartz.Stopped += (s, args) => completedEvent.Set();
            quartz.Start(cts.Token);

            if (!completedEvent.WaitOne(15000))
            {
                Assert.Fail("completedEvent timeout");
            }

            Assert.Equal(11, lstVirt.Count);
            Assert.Equal(11, lstClock.Count);

            Assert.Equal(settings.StartTime, lstClock[0].Time.TimeOfDay);
            Assert.True(settings.EndTime <= lstClock[10].Time.TimeOfDay);
        }

        [Fact]
        public void QuartzStart_WithFactor_01()
        {
            var logger = new Mock<ILogger<Quartz>>().Object;
            var settings = new QuartzSettings
            {
                Date = DateTime.Now,
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(10, 00, 01),
                TimeFactor = 0.1
            };
            var lstVirt = new List<QuartzEventArgs>();
            var lstClock = new List<QuartzEventArgs>();
            var completedEvent = new AutoResetEvent(false);
            using var cts = new CancellationTokenSource();

            var quartz = new Quartz(settings, logger);
            quartz.ErrorOccurred += (s, args) => Assert.Fail("ErrorOccurred event caught");
            quartz.VirtualTimeChanged += (s, args) => lstVirt.Add(args);
            quartz.ClockTimeChanged += (s, args) => lstClock.Add(args);
            quartz.Stopped += (s, args) => completedEvent.Set();
            quartz.Start(cts.Token);

            if (!completedEvent.WaitOne(15000))
            {
                Assert.Fail("completedEvent timeout");
            }

            Assert.Equal(11, lstVirt.Count);
            Assert.Equal(2, lstClock.Count);

            Assert.Equal(settings.StartTime, lstClock[0].Time.TimeOfDay);
            Assert.True(settings.EndTime <= lstClock[1].Time.TimeOfDay);
        }

        [Fact]
        public void QuartzStart_WithFactor_10()
        {
            var logger = new Mock<ILogger<Quartz>>().Object;
            var settings = new QuartzSettings
            {
                Date = DateTime.Now,
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(10, 01, 40),
                TimeFactor = 10.0
            };
            var lstVirt = new List<QuartzEventArgs>();
            var lstClock = new List<QuartzEventArgs>();
            var completedEvent = new AutoResetEvent(false);
            using var cts = new CancellationTokenSource();

            var quartz = new Quartz(settings, logger);
            quartz.ErrorOccurred += (s, args) => Assert.Fail("ErrorOccurred event caught");
            quartz.VirtualTimeChanged += (s, args) => lstVirt.Add(args);
            quartz.ClockTimeChanged += (s, args) => lstClock.Add(args);
            quartz.Stopped += (s, args) => completedEvent.Set();
            quartz.Start(cts.Token);

            if (!completedEvent.WaitOne(15000))
            {
                Assert.Fail("completedEvent timeout");
            }

            Assert.Equal(11, lstVirt.Count);
            Assert.Equal(11, lstClock.Count);

            Assert.Equal(settings.StartTime, lstClock[0].Time.TimeOfDay);
            Assert.True(settings.EndTime <= lstClock[10].Time.TimeOfDay);
        }

        [Fact]
        public void QuartzStart_AndStop()
        {
            var logger = new Mock<ILogger<Quartz>>().Object;
            var settings = new QuartzSettings
            {
                Date = DateTime.Now,
                StartTime = new TimeSpan(10, 00, 00),
                EndTime = new TimeSpan(20, 00, 00),
                TimeFactor = 1.0
            };
            var lstVirt = new List<QuartzEventArgs>();
            var lstClock = new List<QuartzEventArgs>();
            var completedEvent = new AutoResetEvent(false);
            using var cts = new CancellationTokenSource();

            var quartz = new Quartz(settings, logger);
            quartz.ErrorOccurred += (s, args) => Assert.Fail("ErrorOccurred event caught");
            quartz.VirtualTimeChanged += (s, args) => lstVirt.Add(args);
            quartz.ClockTimeChanged += (s, args) => lstClock.Add(args);
            quartz.Stopped += (s, args) => completedEvent.Set();
            quartz.Start(cts.Token);
            Thread.Sleep(3000);
            cts.Cancel();

            if (!completedEvent.WaitOne(3000))
            {
                Assert.Fail("completedEvent timeout");
            }
        }
    }
}