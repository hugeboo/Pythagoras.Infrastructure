using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.WebApi
{
    public sealed class WebApiResult
    {
        public bool Successfully { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }

        public static WebApiResult OK()
        {
            return new WebApiResult { Successfully = true };
        }

        public static WebApiResult Error(IDictionary<string, string[]>? errors)
        {
            return new WebApiResult
            {
                Successfully = false,
                Errors = errors != null ? new(errors) : null
            };
        }

        public static WebApiResult Error(string key, string errorText)
        {
            return new WebApiResult
            {
                Successfully = false,
                Errors = new() { { key, new[] { errorText } } }
            };
        }

        public static WebApiResult Error(Exception ex, string errorText)
        {
            return new WebApiResult
            {
                Successfully = false,
                Errors = new() 
                { 
                    { "ErrorText", new[] { errorText } },
                    { ex.GetType().Name, new[] { ex.Message } }
                }
            };
        }
    }
}
