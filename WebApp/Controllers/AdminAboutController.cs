using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminAboutController : Controller
    {
        private IAboutService _aboutService = new AboutManager(new EfAboutDal());

        private AboutValidator _validator = new AboutValidator();
        private ValidationResult _validation;

        // GET: About
        public ActionResult Index()
        {
            var result = _aboutService.GetAll();

            return View(result);
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _validation = _validator.Validate(about);

            if (_validation.IsValid)
            {
                _aboutService.Add(about);
                return RedirectToAction("Index");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}
