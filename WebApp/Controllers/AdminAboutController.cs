using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.IO;
using System.Linq;
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
            var result = _aboutService.GetAll().SingleOrDefault();

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            about.AboutImageUrl1 = _aboutService.GetAll().SingleOrDefault().AboutImageUrl1;
            about.AboutImageUrl2 = _aboutService.GetAll().SingleOrDefault().AboutImageUrl2;

            _validation = _validator.Validate(about);

            if (_validation.IsValid)
            {
                if (Request.Files["AboutImage1"].ContentLength > 0)
                {
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = Defaults.ABOUT_IMAGE1_URL + extension;

                    Request.Files[0].SaveAs(Server.MapPath(path));

                    about.AboutImageUrl1 = Defaults.ABOUT_IMAGE1_URL + extension;
                }

                if (Request.Files["AboutImage2"].ContentLength > 0)
                {
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = Defaults.ABOUT_IMAGE2_URL + extension;

                    Request.Files[1].SaveAs(Server.MapPath(path));

                    about.AboutImageUrl2 = Defaults.ABOUT_IMAGE1_URL + extension;
                }

                _aboutService.Update(about);

                return RedirectToAction("");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public PartialViewResult AboutPartial()
        {
            var result = _aboutService.GetAll().SingleOrDefault();

            return PartialView(result);
        }
    }
}
