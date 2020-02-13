using System.Web;
using System.Web.Mvc;

namespace CallManagerPanel.MVCWebUI.Library.FilterAttributes
{
    /// <summary>
    /// Controller sınıfına ve ya action methoduna erişim için yeki kontrolü yapar.
    /// Oturum açılmamışsa giriş sayfasına, oturum açılmış fakat yetki sağlanmıyor ise 401 sayfasına yönlendirme yapar.
    /// </summary>
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                throw new HttpException(401, "You are not authorized to view this page.");
            filterContext.Result = new RedirectResult(new UrlHelper(filterContext.RequestContext).Action("SignIn", "Home"));
        }
    }
}