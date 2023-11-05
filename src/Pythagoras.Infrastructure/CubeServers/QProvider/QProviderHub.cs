using Microsoft.AspNetCore.SignalR;
using Pythagoras.Infrastructure.Quotations;
using SignalRSwaggerGen.Attributes;

namespace Pythagoras.Infrastructure.CubeServers.QProvider
{
    [SignalRHub]
    public class QProviderHub : Hub<IQProviderHub>
    {
        public virtual async Task NewTicks(Tick[] ticks)
        {
            await Clients.Others.NewTicks(ticks);
        }
    }
}
