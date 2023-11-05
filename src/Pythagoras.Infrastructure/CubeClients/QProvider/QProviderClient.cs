using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pythagoras.Infrastructure.CubeClients.ClockSignal;
using Pythagoras.Infrastructure.Quotations;
using Pythagoras.Infrastructure.Realtime;
using Pythagoras.Infrastructure.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypedSignalR.Client;

namespace Pythagoras.Infrastructure.CubeClients.QProvider
{
    public sealed class QProviderClient : IQProviderClient, IQProviderReceiver, IHubConnectionObserver
    {
        public const string HUB_URL_PATH = "/QProviderHub";

        private readonly string _serverUrl;
        private readonly ILogger<QProviderClient> _logger;
        private HubConnection _hubConnection = default!;

        //public event EventHandler<TicksEventArgs>? NewTicksReceived;
        public event EventHandler<StringEventArgs>? QProviderStateChanged;

        public QProviderClient(string serverUrl, ILogger<QProviderClient> logger)
        {
            _serverUrl = serverUrl ?? throw new ArgumentNullException(nameof(serverUrl));
            _logger = logger;
        }

        public async Task InitializeAndStartHubConnectionAsync()
        {
            var url = _serverUrl + HUB_URL_PATH;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(url, HttpTransportType.WebSockets)
                .WithAutomaticReconnect()
                //added by default, options not supported in JavaScript
                .AddJsonProtocol(options =>
                {
                    //by default
                    options.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
                //not added by default
                //MessagePackProtocol IS NOT JsonProtocol compatible !!!
                //.AddMessagePackProtocol()
                .Build();

            //hubProxy = connection.ServerProxy<IStickyNoteHub>();
            _ = _hubConnection.ClientRegistration<IQProviderReceiver>(this);

            _logger?.LogInformation($"Hub starting. Url={url}");
            await _hubConnection.StartAsync();
        }

        public Task OnClosed(Exception? exception)
        {
            // TODO: exception ???
            _logger?.LogInformation("StateChanged to 'HubClosed'");
            QProviderStateChanged?.Invoke(this, new StringEventArgs("HubClosed"));
            return Task.CompletedTask;
        }

        public Task OnReconnected(string? connectionId)
        {
            _logger?.LogInformation("StateChanged to 'HubReconnected'");
            QProviderStateChanged?.Invoke(this, new StringEventArgs("HubReconnected"));
            return Task.CompletedTask;
        }

        public Task OnReconnecting(Exception? exception)
        {
            // TODO: exception ???
            _logger?.LogInformation("StateChanged to 'HubReconnecting'");
            QProviderStateChanged?.Invoke(this, new StringEventArgs("HubReconnecting"));
            return Task.CompletedTask;
        }

        public Task NewTicks(Tick[] ticks)
        {
            throw new NotImplementedException();
        }
    }
}
