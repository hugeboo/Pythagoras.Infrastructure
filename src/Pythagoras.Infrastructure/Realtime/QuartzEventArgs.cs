using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Realtime
{
    public sealed class QuartzEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            var s = Time.ToString("dd.MM.yy HH:mm:ss.fff");
            if (Message != null)
            {
                s += $": {Message}";
            }
            return s;
        }
    }
}
