using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminAboutController : Controller
    {
        private IAboutService _aboutService = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var result = _aboutService.GetAll();

            return View(result);
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutService.Add(about);

            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}
