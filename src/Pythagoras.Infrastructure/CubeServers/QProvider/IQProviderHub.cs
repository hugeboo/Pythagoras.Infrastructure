using Pythagoras.Infrastructure.Quotations;

namespace Pythagoras.Infrastructure.CubeServers.QProvider
{
    public interface IQProviderHub
    {
        Task NewTicks(Tick[] ticks);
    }
}
