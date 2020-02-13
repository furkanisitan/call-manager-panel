using CallManagerPanel.Business.Abstract;
using CallManagerPanel.MVCWebUI.Library.Helpers;
using CallManagerPanel.MVCWebUI.Library.Helpers.MappingHelpers;
using CallManagerPanel.MVCWebUI.Models;
using System.Web.Mvc;
using CallManagerPanel.MVCWebUI.Library.FilterAttributes;

namespace CallManagerPanel.MVCWebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Profile(string id)
        {
            var user = _userService.GetByIdWithRoles(HashidsHelper.Decrypt(id));
            var vm = user.MapTo<UserVm>();
            return View(vm);
        }
    }
}