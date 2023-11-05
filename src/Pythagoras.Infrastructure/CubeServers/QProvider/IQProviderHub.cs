using Pythagoras.Infrastructure.Quotations;

namespace Pythagoras.Infrastructure.CubeServers.QProvider
{
    public interface IQProviderHub
    {
        Task NewTick(Tick tick);
    }
}
