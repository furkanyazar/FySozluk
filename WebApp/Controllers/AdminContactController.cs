using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminContactController : Controller
    {
        private IContactService _contactService = new ContactManager(new EfContactDal());

        // GET: AdminContact
        public ActionResult Index()
        {
            var result = _contactService.GetAll().OrderByDescending(x => x.ContactDate).ToList();

            return View(result);
        }

        public ActionResult Message(int id)
        {
            var result = _contactService.GetById(id);

            if (!result.ContactStatus)
            {
                result.ContactStatus = true;

                _contactService.Update(result);
            }

            return View(result);
        }

        public PartialViewResult ContactPartial()
        {
            var result = _contactService.GetAll();

            return PartialView(result);
        }
    }
}
