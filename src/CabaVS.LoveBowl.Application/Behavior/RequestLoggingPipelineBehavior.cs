using CabaVS.LoveBowl.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace CabaVS.LoveBowl.Application.Behavior;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
        ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest: class
    where TResponse: Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        logger.LogInformation("Processing request {RequestName}.", requestName);

        var result = await next();
        if (result.IsSuccess)
        {
            logger.LogInformation("Completed request {RequestName}.", requestName);   
        }
        else
        {
            using (LogContext.PushProperty("Error", result.Error, true))
            {
                logger.LogWarning("Completed request {RequestName} with error.", requestName);   
            }
        }

        return result;
    }
}