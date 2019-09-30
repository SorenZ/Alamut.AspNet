using System;

using Alamut.Abstractions.Structure;

namespace Alamut.AspNet.ExceptionMiddleware
{
    public class ApiExceptionHandlerOptions
    {
        /// <summary>
        /// if set true 
        /// determine wether the request is ajax call or not by cheking if request header that contains X-Requested-With = XMLHttpRequest
        /// </summary>
        /// <value></value>
        /// <default>true</default>
        public bool HandleAjaxCallOnly { get; set; } = false;
        
        /// <summary>
        /// identify the building of result from exception
        /// </summary>
        /// <value></value>
        public Func<Exception, object> ResultBuilder { get; set; } =
            ex => new Result
            {
                Succeed = false,
                Message = ex.Message,
                StatusCode = 500,
            };
    }
}