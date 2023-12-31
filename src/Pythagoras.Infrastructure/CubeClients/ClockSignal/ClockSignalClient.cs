﻿using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Pythagoras.Infrastructure.Realtime;
using Pythagoras.Infrastructure.SignalR;
using Pythagoras.Infrastructure.WebApi;
using Refit;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.CubeClients.ClockSignal
{
    public sealed class ClockSignalClient : IClockSignalClient, IClockSignalReceiver, IHubConnectionObserver
    {
        public const string HUB_URL_PATH = "/ClockSignalHub";

        private readonly string _serverUrl;
        private IClockSignalWebApi _webApi = default!;
        private HubConnection _hubConnection = default!;

        public event EventHandler<TimeEventArgs>? ClockTimeChanged;
        public event EventHandler<TimeEventArgs>? VirtualTimeChanged;
        public event EventHandler<StringEventArgs>? ClockSignalStateChanged;

        public ClockSignalClient(string serverUrl)
        {
            _serverUrl = serverUrl ?? throw new ArgumentNullException(nameof(serverUrl));
        }

        public void InitializeWebApiClient()
        {
            var refitSettings = new RefitSettings(
                         new SystemTextJsonContentSerializer(
                             new JsonSerializerOptions()
                             {
                                 WriteIndented = true,
                                 PropertyNameCaseInsensitive = true,
                                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                 Converters = {
                                         new JsonStringEnumConverter(),
                                         new ObjectToInferredTypesConverter()
                                 }
                             })
                         );

            // TODO: Use refitSettings ?
            _webApi = RestService.For<IClockSignalWebApi>(_serverUrl);//, refitSettings);
        }

        public async Task InitializeAndStartHubConnectionAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_serverUrl + HUB_URL_PATH, HttpTransportType.WebSockets)
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
            _ = _hubConnection.ClientRegistration<IClockSignalReceiver>(this);

            await _hubConnection.StartAsync();
        }

        public async Task<WebApiResult<ClockSignalSettings>> GetSettingsAsync()
        {
            return await _webApi.GetSettingsAsync();
        }

        public async Task SetSettingsAsync(ClockSignalSettings settings)
        {
            await _webApi.SetSettingsAsync(settings);
        }

        public async Task<WebApiResult<ClockSignalState>> GetStateAsync()
        {
            return await _webApi.GetStateAsync();
        }

        public async Task<WebApiResult> StartAsync()
        {
            return await _webApi.StartAsync();
        }

        public async Task<WebApiResult> StopAsync()
        {
            return await _webApi.StopAsync();
        }

        public Task NewClockTime(DateTime time)
        {
            ClockTimeChanged?.Invoke(this, new TimeEventArgs(time));
            return Task.CompletedTask;
        }

        public Task NewVirtualTime(DateTime time)
        {
            VirtualTimeChanged?.Invoke(this, new TimeEventArgs(time));
            return Task.CompletedTask;
        }

        public Task StateChanged(string state)
        {
            ClockSignalStateChanged?.Invoke(this, new StringEventArgs(state));
            return Task.CompletedTask;
        }

        public Task OnClosed(Exception? exception)
        {
            // TODO: exception ???
            ClockSignalStateChanged?.Invoke(this, new StringEventArgs("HubClosed"));
            return Task.CompletedTask;
        }

        public Task OnReconnected(string? connectionId)
        {
            ClockSignalStateChanged?.Invoke(this, new StringEventArgs("HubReconnected"));
            return Task.CompletedTask;
        }

        public Task OnReconnecting(Exception? exception)
        {
            // TODO: exception ???
            ClockSignalStateChanged?.Invoke(this, new StringEventArgs("HubReconnecting"));
            return Task.CompletedTask;
        }
    }
}
