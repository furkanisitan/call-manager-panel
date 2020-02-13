using CallManagerPanel.Business.DependencyResolvers.Ninject;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Web;
using CallManagerPanel.Core.Utilities.Mvc.Infrastructure;
using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CallManagerPanel.MVCWebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Controller olu�turma y�ntemini ayarlar.
            // Bu sayede ninject ile controller lara dependency injection yap�labilir.
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }

        // Uygulamadaki t�m hatalar burada yakalanabilir.
        protected void Application_Error(object sender, EventArgs e)
        {
            var httpException = Server.GetLastError() as HttpException;
            if (httpException == null) return;
            if (httpException.GetHttpCode() == 401)
                Response.Redirect("~/401.html");
        }

        public override void Init()
        {
            // Kimlik do�rulama iste�i olay dinleyicisi
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        // Giri� yapan kullan�c�n�n bilgileri cookie ye eklenir.
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) return;

                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket)) return;

                var ticket = FormsAuthentication.Decrypt(encTicket);
                var identity = SecurityUtilities.FormsAuthenticationTicketToIdentity(ticket);
                var principal = new CustomPrincipal(identity);

                HttpContext.Current.User = principal;   // Web i�in
                Thread.CurrentPrincipal = principal;    // Back-end i�in
            }
            catch
            {
                // ignored
            }
        }
    }
}
