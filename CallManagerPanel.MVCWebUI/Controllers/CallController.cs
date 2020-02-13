using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Entities.Concrete;
using CallManagerPanel.MVCWebUI.Library;
using CallManagerPanel.MVCWebUI.Library.FilterAttributes;
using CallManagerPanel.MVCWebUI.Library.Helpers;
using CallManagerPanel.MVCWebUI.Library.Helpers.MappingHelpers;
using CallManagerPanel.MVCWebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace CallManagerPanel.MVCWebUI.Controllers
{
    [ValidateHeaderAntiForgeryToken, HttpRequestHandler]
    public class CallController : Controller
    {
        private readonly ICallService _callService;

        public CallController(ICallService callService)
        {
            _callService = callService;
        }

        [HttpPost]
        public ActionResult Create(CallVm model)
        {
            _callService.Add(model.MapTo<Call>());
            return Json(new { success = true, message = C.Message.Success });
        }

        [HttpPost]
        public ActionResult Update(CallVm model)
        {
            _callService.Update(model.MapTo<Call>());
            return Json(new { success = true, message = C.Message.Success });
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            _callService.DeleteById(HashidsHelper.Decrypt(id));
            return Json(new { success = true, message = C.Message.Success });
        }

        [HttpPost]
        public ActionResult GetCallsAsJson(string contactId)
        {
            var calls = _callService.GetAllByContactIdWithUsers(HashidsHelper.Decrypt(contactId));
            var vm = calls.Select(x => x.MapTo<CallVm>());
            return Json(new { success = true, data = vm });
        }

        [HttpPost]
        public ActionResult GetCallAsJson(string id)
        {
            var call = _callService.GetById(HashidsHelper.Decrypt(id));
            var vm = call.MapTo<CallVm>();
            return Json(new { success = true, data = vm });
        }
    }
}