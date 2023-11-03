using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Realtime
{
    public sealed class QuartzSettings : ICloneable
    {
        public DateTime Date { get; set; } = DateTime.Today;
        public TimeSpan StartTime { get; set; } = new TimeSpan(10, 00, 00);
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 45, 00);
        public double TimeFactor { get; set; } = 1.0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
