using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Quotations
{
    public sealed class Tick
    {
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public long Size { get; set; }
        public TickType Type { get; set; }
    }
}
