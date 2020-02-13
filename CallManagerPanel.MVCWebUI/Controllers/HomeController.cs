using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Web;
using CallManagerPanel.MVCWebUI.Library;
using CallManagerPanel.MVCWebUI.Library.FilterAttributes;
using CallManagerPanel.MVCWebUI.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace CallManagerPanel.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IContactService _contactService;

        public HomeController(IUserService userService, IContactService contactService)
        {
            _userService = userService;
            _contactService = contactService;
        }

        [CustomAuthorize]
        public ActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public ActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.AlertMessage = TempData[C.Keys.ViewData.AlertMessage];

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginVm model)
        {
            var user = _userService.GetByUsernamePassword(model.User.Username, model.User.Password, true);

            if (user == null)
            {
                TempData[C.Keys.ViewData.AlertMessage] = "Giriş yapılamadı!\nKullanıcı adı ya da şifre hatalı.";
                return RedirectToAction("SignIn", "Home");
            }

            // Giriş yap
            AuthenticationHelper.CreateAuthCookie(
                username: user.Username,
                roles: user.Roles.Select(x => x.Name).ToArray(),
                rememberMe: model.RememberMe,
                expires: DateTime.Now.AddDays(1),
                id: user.Id,
                fullname: user.Fullname);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}