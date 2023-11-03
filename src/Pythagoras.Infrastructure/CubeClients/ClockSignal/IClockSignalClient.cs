using Pythagoras.Infrastructure.Realtime;
using Pythagoras.Infrastructure.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public interface IClockSignalClient
    {
        event EventHandler<TimeEventArgs>? ClockTimeChanged;
        event EventHandler<TimeEventArgs>? VirtualTimeChanged;
        event EventHandler<StringEventArgs>? ClockSignalStateChanged;

        Task<WebApiResult<ClockSignalSettings>> GetSettingsAsync();
        Task<WebApiResult<ClockSignalState>> GetStateAsync();
        Task SetSettingsAsync(ClockSignalSettings settings);
        Task<WebApiResult> StartAsync();
        Task<WebApiResult> StopAsync();

        void InitializeWebApiClient();
        Task InitializeAndStartHubConnectionAsync();
    }
}
