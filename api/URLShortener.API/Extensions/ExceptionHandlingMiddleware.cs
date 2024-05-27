using System.Net;

namespace URLShortener.API.Extensions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid();

                _logger.LogError("An error occured. {ExceptionType}. {ExceptionMessage}. {CorrelationId}.",
                    ex.GetType().FullName,
                    ex.Message,
                    correlationId);

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync($"An error occured. Correlation ID: {correlationId}.");
            }
        }
    }
}
