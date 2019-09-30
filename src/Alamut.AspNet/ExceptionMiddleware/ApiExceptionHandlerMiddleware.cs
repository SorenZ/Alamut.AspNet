using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Alamut.AspNet.Http;

namespace Alamut.AspNet.ExceptionMiddleware
{
    /// <summary>
    /// provide custom error handling response for Web API.
    /// </summary>
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlerMiddleware> _logger;
        private readonly ApiExceptionHandlerOptions _options;

        public ApiExceptionHandlerMiddleware(RequestDelegate next, 
            ILogger<ApiExceptionHandlerMiddleware> logger,
            ApiExceptionHandlerOptions options)
        {
            _next = next;
            _logger = logger;
            _options = options;
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

                if(_options.HandleAjaxCallOnly)
                {
                    if(!context.Request.IsAjax())
                    {
                        throw;
                    }
                }

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // var code = StatusCodes.Status500InternalServerError; // 500 if unexpected
            // var serviceResult = ServiceResult.Exception(ex);
            // var serviceResult = new Result
            // {
            //     Succeed = false,
            //     Message = ex.Message
            // };

            var result = _options.ResultBuilder.Invoke(ex);
            // result.StatusCode = StatusCodes.Status500InternalServerError;

            //if      (ex is MyNotFoundException)     code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is MyException)             code = HttpStatusCode.BadRequest;

            //var result = JsonConvert.SerializeObject(new { error = ex.Message });
            
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 
                (result is Abstractions.Structure.Result rsl) 
                    ? rsl.StatusCode 
                    : StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
