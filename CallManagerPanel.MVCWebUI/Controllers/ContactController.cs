using CallManagerPanel.Business.Abstract;
using CallManagerPanel.MVCWebUI.Library.FilterAttributes;
using CallManagerPanel.MVCWebUI.Library.Helpers;
using CallManagerPanel.MVCWebUI.Library.Helpers.MappingHelpers;
using CallManagerPanel.MVCWebUI.Models;
using System.Web.Mvc;
using CallManagerPanel.Entities.Concrete;
using CallManagerPanel.MVCWebUI.Library;

namespace CallManagerPanel.MVCWebUI.Controllers
{
    [ValidateHeaderAntiForgeryToken, HttpRequestHandler]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public ActionResult Create(ContactVm model)
        {
            var contact = _contactService.Add(model.MapTo<Contact>());
            return Json(new { success = true, message = C.Message.Success, contactId = HashidsHelper.Encrypt(contact.Id) });
        }

        [HttpPost]
        public ActionResult Update(ContactVm model)
        {
            _contactService.Update(model.MapTo<Contact>());
            return Json(new { success = true, message = C.Message.Success });
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            _contactService.DeleteById(HashidsHelper.Decrypt(id));
            return Json(new { success = true, message = C.Message.Success });
        }

        [HttpPost]
        public ActionResult GetContactAsJson(string id)
        {
            var vm = _contactService.GetById(HashidsHelper.Decrypt(id)).MapTo<ContactVm>();
            return Json(new { success = true, data = vm }, JsonRequestBehavior.AllowGet);
        }
    }
}