using Microsoft.AspNetCore.Diagnostics;

namespace RepositoryPattern.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Request received: {Method} {Path}", context.Request.Method, context.Request.Path);

            await next(context);

            _logger.LogInformation("Response sent: {StatusCode}", context.Response.StatusCode);
        }

        
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
