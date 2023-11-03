using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.Realtime
{
    public sealed class StringEventArgs : EventArgs
    {
        public string Text { get; }
        public StringEventArgs(string text) => Text = text;
    }
}
