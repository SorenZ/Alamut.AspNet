using System;
using System.Threading.Tasks;
using Alamut.AspNet.Http;
using Alamut.Abstractions.Structure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Alamut.AspNet.ExceptionMiddleware
{
    /// <summary>
    /// provide custom error handling response for Web API.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly bool _isAjaxOnly;

        public ErrorHandlingMiddleware(RequestDelegate next, 
            ILogger<ErrorHandlingMiddleware> logger,
            bool isAjaxOnly)
        {
            _next = next;
            _logger = logger;
            _isAjaxOnly = isAjaxOnly;
            // _isAjaxOnly = true;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an unhandled exception occurred");

                if(_isAjaxOnly)
                {
                    if(!context.Request.IsAjax())
                    {
                        return;
                    }
                }

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = StatusCodes.Status500InternalServerError; // 500 if unexpected
            // var serviceResult = ServiceResult.Exception(ex);
            var serviceResult = new Result
            {
                Succeed = false,
                Message = ex.Message
            };

            //if      (ex is MyNotFoundException)     code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException)             code = HttpStatusCode.BadRequest;

            //var result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(serviceResult));
        }
    }

    /// <summary>
    /// provide custom error handling in ServiceResult format for Web API.
    /// </summary>
    public static class ErrorHandlingExtensions
    {

        public static IApplicationBuilder UseServiceResultException(this IApplicationBuilder source, bool justHandleAjaxCall = true) =>
            source.UseMiddleware<ErrorHandlingMiddleware>(justHandleAjaxCall);
    }
}
