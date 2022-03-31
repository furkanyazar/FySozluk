using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminContactController : Controller
    {
        private IContactService _contactService = new ContactManager(new EfContactDal());

        // GET: AdminContact
        public ActionResult Index()
        {
            var result = _contactService.GetAll();

            return View(result);
        }

        public ActionResult Message(int id)
        {
            var result = _contactService.GetById(id);

            return View(result);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}
