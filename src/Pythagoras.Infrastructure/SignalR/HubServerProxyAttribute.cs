using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.SignalR
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class HubServerProxyAttribute : Attribute { }
}
