using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Quotations
{
    public sealed class TicksEventArgs : EventArgs
    {
        public Tick[] Ticks { get; }
        public TicksEventArgs(Tick[] ticks) => Ticks = ticks;
    }
}
