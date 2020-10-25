using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Web.MVC.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode}";

        static readonly ILogger Log = Serilog.Log.ForContext<ErrorLoggingMiddleware>();

        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Log.Information($"Before Request:{context.Request.Path}");

                await _next(context);

               // Log.Information($"After Request:{context.Request.Path}");

            }
            catch (Exception ex) 
            {
                var request = context.Request;

                var result = Log
                    .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
                    .ForContext("RequestHost", request.Host)
                    .ForContext("RequestProtocol", request.Protocol);

                if (request.HasFormContentType)
                    result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

                result.Error(ex, MessageTemplate, context.Request.Method, context.Request.Path, 500);

                throw;
            }

        }

        
    }
}
