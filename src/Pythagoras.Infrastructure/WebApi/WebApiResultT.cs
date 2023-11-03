using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.WebApi
{
    public sealed class WebApiResult<T> where T : class
    {
        public bool Successfully { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
        public T? Result { get; set; }

        public static WebApiResult<T> OK(T result)
        {
            return new WebApiResult<T> { Successfully = true, Result = result };
        }

        public static WebApiResult<T> Error(IDictionary<string, string[]>? errors)
        {
            return new WebApiResult<T>
            {
                Successfully = false,
                Errors = errors != null ? new(errors) : null
            };
        }

        public static WebApiResult<T> Error(string key, string errorText)
        {
            return new WebApiResult<T>
            {
                Successfully = false,
                Errors = new() { { key, new[] { errorText } } }
            };
        }

        public static WebApiResult<T> Error(Exception ex, string errorText)
        {
            return new WebApiResult<T>
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
