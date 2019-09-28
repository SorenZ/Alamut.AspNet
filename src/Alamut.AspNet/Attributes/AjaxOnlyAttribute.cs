using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

using Alamut.AspNet.Http;

namespace Alamut.AspNet.Attributes
{
    /// <summary>
    /// https://dotnetthoughts.net/detecting-ajax-requests-in-aspnet-core/
    /// </summary>
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjax();
        }
    }
}