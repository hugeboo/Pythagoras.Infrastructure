using Pythagoras.Infrastructure.WebApi;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public interface IClockSignalWebApi
    {
        [Get("/ClockSignal/Settings")]
        Task<WebApiResult<ClockSignalSettings>> GetSettingsAsync();

        [Post("/ClockSignal/Settings")]
        Task<WebApiResult> SetSettingsAsync([Body]ClockSignalSettings settings);

        [Post("/ClockSignal/Start")]
        Task<WebApiResult> StartAsync();

        [Post("/ClockSignal/Stop")]
        Task<WebApiResult> StopAsync();

        [Get("/ClockSignal/State")]
        Task<WebApiResult<ClockSignalState>> GetStateAsync();
    }
}
