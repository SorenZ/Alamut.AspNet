using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Alamut.AspNet.TextMiddleware
{
    public class TextValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TextValidatorMiddleware> _logger;

        const string AY = "%D9%8A";
        const string AK = "%D9%83";

        const string PY = "%DB%8C";
        const string PK = "%DA%A9";

        public TextValidatorMiddleware(RequestDelegate next, ILogger<TextValidatorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post &&
                context.Request.ContentType == "application/x-www-form-urlencoded")
            {
                var body = new StreamReader(context.Request.Body).ReadToEnd();

                _logger.LogWarning(body);

                var requestData = Encoding.UTF8.GetBytes(body.Replace(AY, PY).Replace(AK, PK));
                context.Request.Body = new MemoryStream(requestData);
            }
            await _next.Invoke(context);
        }
    }

    #region ExtensionMethod
    public static class TextValidatiorExtension
    {
        public static IApplicationBuilder ApplyTextValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<TextValidatorMiddleware>();
            return app;
        }
    }
    #endregion
}
