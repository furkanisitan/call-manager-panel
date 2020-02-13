using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CallManagerPanel.MVCWebUI.Library.FilterAttributes
{
    /// <summary>
    /// HTTP isteğiyle gelen header bilgilerinde __RequestVerificationToken kontrolü yapar.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class ValidateHeaderAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));

            var httpContext = filterContext.HttpContext;
            var serverToken = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
            var clientToken = httpContext.Request.Headers["__RequestVerificationToken"];
            AntiForgery.Validate(serverToken?.Value, clientToken);
        }
    }
}