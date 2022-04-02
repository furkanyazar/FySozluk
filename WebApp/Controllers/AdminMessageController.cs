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
        private IDraftService _draftService = new DraftManager(new EfDraftDal());

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

        public ActionResult Draftbox()
        {
            var result = _draftService.GetAllOfSentByEmail("admin");

            return View(result);
        }

        public ActionResult Trashbox()
        {
            var result = _messageService.GetAllOfDeletedByEmail("admin");

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
        [ValidateInput(false)]
        public ActionResult AddMessage(Message message)
        {
            message.SenderEmail = "admin";
            _validation = _validator.Validate(message);

            if (_validation.IsValid)
            {
                _messageService.Add(message);
                return RedirectToAction("Inbox");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddMessageFromDraft(int id)
        {
            var result = _draftService.GetById(id);

            var message = new Message();
            message.MessageSubject = result.MessageSubject;
            message.MessageContent = result.MessageContent;
            message.ReceiverEmail = result.ReceiverEmail;

            return View(message);
        }

        [HttpPost]
        public ActionResult AddMessageFromDraft(Message message)
        {
            _validation = _validator.Validate(message);

            if (_validation.IsValid)
            {
                _messageService.Add(message);
                return RedirectToAction("Inbox");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public ActionResult AddDraft(Message message)
        {
            Draft draft = new Draft();
            draft.SenderEmail = "admin";
            draft.MessageContent = message.MessageContent;
            draft.MessageSubject = message.MessageSubject;
            draft.ReceiverEmail = message.ReceiverEmail;

            if (draft.MessageSubject != null || draft.MessageContent != null || draft.ReceiverEmail != null)
            {
                _draftService.Add(draft);
            }

            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessage(int id)
        {
            var result = _messageService.GetById(id);

            if (result.MessageIsDeleted)
            {
                _messageService.Delete(result);
            }
            else
            {
                result.MessageIsDeleted = true;
                _messageService.Update(result);
            }

            return result.SenderEmail == "admin" ? RedirectToAction("Sendbox") : RedirectToAction("Inbox");
        }

        public ActionResult DeleteDraft(int id)
        {
            var result = _draftService.GetById(id);

            _draftService.Delete(result);

            return RedirectToAction("Draftbox");
        }

        public void DeleteDraftFromDraft(int id)
        {
            var result = _draftService.GetById(id);

            _draftService.Delete(result);
        }

        public PartialViewResult MessagePartial()
        {
            var result = _messageService.GetAllOfReceivedByEmail("admin");

            return PartialView(result);
        }
    }
}
