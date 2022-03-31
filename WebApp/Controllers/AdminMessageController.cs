using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminMessageController : Controller
    {
        private IMessageService _messageService = new MessageManager(new EfMessageDal());

        private MessageValidator _validator = new MessageValidator();
        private ValidationResult _validation;

        // GET: Message
        public ActionResult Inbox()
        {
            var result = _messageService.GetAllOfReceivedByEmail("admin").OrderByDescending(x => x.MessageDate).ToList();

            return View(result);
        }

        public ActionResult Sendbox()
        {
            var result = _messageService.GetAllOfSentByEmail("admin").OrderByDescending(x => x.MessageDate).ToList();

            return View(result);
        }

        public ActionResult Message(int id)
        {
            var result = _messageService.GetById(id);

            if (!result.MessageStatus)
            {
                result.MessageStatus = true;

                _messageService.Update(result);
            }

            return View(result);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            _validation = _validator.Validate(message);

            if (_validation.IsValid)
            {
                _messageService.Add(message);
                return RedirectToAction("Index");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
