using System.IO;
using System.Text;
using System.Threading.Tasks;
using lesson6_1.Services;
using Microsoft.AspNetCore.Http;

namespace lesson6_1.MiddleWares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsyn(HttpContext httpContext, IDbService service)
        {
            httpContext.Request.EnableBuffering();
            if (httpContext.Request != null)
            {
                string path = httpContext.Request.Path;
                var queryString = httpContext.Request.QueryString.ToString();
                var method = httpContext.Request.Method;
                string bodyParameters;
                using (StreamReader reader =
                    new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyParameters = await reader.ReadToEndAsync();
                    httpContext.Request.Body.Position = 0;
                }

                await using var streamWriter = new StreamWriter(@"Logs/requestsLog.txt", true);
                streamWriter.WriteLine("1. HTTP Method (" + httpContext.Request.Method + ")\n" +
                                       "2. Endpoint Path (" + httpContext.Request.Path + ")\n" +
                                       "3. Body of each request (" + bodyParameters + ")\n" +
                                       "4. Query strings (" + queryString + ")\n\n");
            }

            await _next(httpContext);
        }
    }
}