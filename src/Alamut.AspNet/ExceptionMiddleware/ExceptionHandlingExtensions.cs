using Microsoft.AspNetCore.Builder;

namespace Alamut.AspNet.ExceptionMiddleware
{
    /// <summary>
    /// provide custom error handling in Result format for Web API.
    /// </summary>
    public static class ExceptionHandlerExtensions
    {

        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder source, ApiExceptionHandlerOptions options) =>
            source.UseMiddleware<ApiExceptionHandlerMiddleware>(options);
    }
}
