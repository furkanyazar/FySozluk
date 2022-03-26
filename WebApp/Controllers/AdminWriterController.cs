using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminWriterController : Controller
    {
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: Writer
        public ActionResult Index()
        {
            var result = _writerService.GetAll();

            return View(result);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var result = _writerService.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            if (writer.WriterPassword is null)
            {
                writer.WriterPassword = _writerService.GetById(writer.WriterId).WriterPassword;
            }

            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
