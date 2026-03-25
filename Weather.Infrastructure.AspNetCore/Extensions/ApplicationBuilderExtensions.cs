using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Weather.Infrastructure.AspNetCore.Middlewares;

namespace Weather.Infrastructure.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePing(this IApplicationBuilder app)
        {
            return app.Map(
                "/ping",
                applicationBuilder => applicationBuilder
                    .Run(async httpContext => await httpContext.Response.WriteAsync("pong").ConfigureAwait(false)));
        }

        public static IApplicationBuilder UseStartRedirect(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/" || context.Request.Path == string.Empty)
                {
                    context.Response.Redirect("/ping");
                    return;
                }
                await next();
            });
        }

        public static IApplicationBuilder UseDefaultExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}