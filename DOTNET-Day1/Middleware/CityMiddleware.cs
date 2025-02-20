using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day1.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CityMiddleware
    {
        private readonly RequestDelegate _next;

        public CityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path == "/api/Weather/Weather/PostRequest")
            {
                if (httpContext.Request.Query["city"].ToString().ToLower() == "ahmedabad")
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 403;                      
                    await httpContext.Response.WriteAsync("city should be Ahmedabad");
                    return;
                }
            }
            

            
        }
    }
    
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CityMiddleware>();
        }
    }
}
