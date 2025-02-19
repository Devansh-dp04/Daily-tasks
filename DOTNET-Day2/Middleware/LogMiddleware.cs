using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DOTNET_Day2.NewFolder
{
   
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            DateTime time = DateTime.Now;
            Thread.Sleep(3000);
            Console.WriteLine($"Request received at {time}");
            return _next(httpContext);
        }
    }   
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
