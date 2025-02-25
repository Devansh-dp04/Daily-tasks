using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Medicare_.Middleware
{
   
    public class ReqMiddleware
    {
        private readonly RequestDelegate _next;

        public ReqMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ReqMiddlewareExtensions
    {
        public static IApplicationBuilder UseReqMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReqMiddleware>();
        }
    }
}
