using Serilog.Context;

namespace CabaVS.LoveBowl.WebApi.Middleware;

internal sealed class RequestLoggingMiddleware(RequestDelegate next)
{
    public Task InvokeAsync(HttpContext context)
    {
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            return next(context);
        }
    }
}