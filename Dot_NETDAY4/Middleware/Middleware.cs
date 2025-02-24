using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dot_NETDAY4.Middleware
{
    
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Request received");
            if (httpContext.Request.Query["id"] == "bacancy")
            {
                return ;
            }
            await _next(httpContext);
            Console.Write(httpContext.Response);
            Console.WriteLine("Response sent");            
        }
    }    
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
