using System;
using System.Web.Mvc;

namespace CallManagerPanel.MVCWebUI.Library.FilterAttributes
{
    /// <summary>
    /// HTTP isteklerinde hata kontrolü sağlar. Hata varsa JSON olarak döner.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class HttpRequestHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, message = filterContext.Exception.InnerException?.Message ?? filterContext.Exception.Message },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}