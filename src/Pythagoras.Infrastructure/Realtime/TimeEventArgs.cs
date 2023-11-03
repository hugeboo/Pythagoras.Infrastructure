using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Realtime
{
    public sealed class TimeEventArgs : EventArgs
    {
        public DateTime Time { get; }
        public TimeEventArgs(DateTime time) => Time = time;
    }
}
