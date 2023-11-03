using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.SignalR
{
    public static partial class HubConnectionExtensions
    {
        [HubClientProxy]
        public static partial IDisposable ClientRegistration<T>(this HubConnection connection, T provider);

        [HubServerProxy]
        public static partial T ServerProxy<T>(this HubConnection connection);
    }
}
