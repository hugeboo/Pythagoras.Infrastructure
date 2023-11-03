using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public interface IClockSignalReceiver
    {
        Task NewClockTime(DateTime time);
        Task NewVirtualTime(DateTime time);
        Task StateChanged(string state);
    }
}
