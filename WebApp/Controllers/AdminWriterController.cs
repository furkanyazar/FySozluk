using Business.Abstract;
using Business.Concrete;
using Business.Constants;
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

        private WriterValidator _validator = new WriterValidator();
        private ValidationResult _validation;

        // GET: Writer
        public ActionResult Index()
        {
            var result = _writerService.GetAll();

            foreach (var item in result)
            {
                if (item.WriterImageUrl is null)
                {
                    item.WriterImageUrl = Defaults.DEFAULT_WRITER_IMAGE_URL;
                }
            }

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
            _validation = _validator.Validate(writer);

            if (_validation.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index");
            }

            foreach (var item in _validation.Errors)
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

            _validation = _validator.Validate(writer);

            if (_validation.IsValid)
            {
                _writerService.Update(writer);
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
