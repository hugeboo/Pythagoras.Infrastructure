using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public sealed class ClockSignalSettings : ICloneable
    {
        public enum ClockSignalMode
        {
            Realtime = 0,
            Backtesting = 1
        }

        public ClockSignalMode Mode { get; set; } = ClockSignalMode.Realtime;

        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public TimeSpan StartTime { get; set; } = new TimeSpan(10, 00, 00);
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 45, 00);

        public double TimeFactor { get; set; } = 1.0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public sealed class ClockSignalSettingsEventArgs : EventArgs
    {
        public ClockSignalSettings Settings { get; set; } = new ClockSignalSettings();
    }
}
