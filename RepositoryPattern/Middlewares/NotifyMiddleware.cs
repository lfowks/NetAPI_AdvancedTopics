using Microsoft.AspNetCore.Diagnostics;

namespace RepositoryPattern.Middlewares
{
    public class NotifyMiddleware : IMiddleware
    {
        private readonly ILogger<NotifyMiddleware> _logger;

        public NotifyMiddleware(ILogger<NotifyMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Notify received: {Method} {Path}", context.Request.Method, context.Request.Path);

            await next(context);

            _logger.LogInformation("Notify sent: {StatusCode}", context.Response.StatusCode);
        }

        
    }

    public static class NotifyMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotifyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotifyMiddleware>();
        }
    }
}
