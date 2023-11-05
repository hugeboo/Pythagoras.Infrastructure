using Pythagoras.Infrastructure.Quotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.QProvider
{
    public interface IQProviderReceiver
    {
        Task NewTicks(Tick[] ticks);
    }
}
