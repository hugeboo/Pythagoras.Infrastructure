using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public sealed class ClockSignalState
    {
        public bool IsRunning { get; set; } = false;
        public bool IsError { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }

    public sealed class ClockSignalStateEventArgs : EventArgs
    {
        public ClockSignalState State { get; set; } = new ClockSignalState();
    }
}
