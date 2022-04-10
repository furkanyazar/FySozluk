using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class WriterPanelController : Controller
    {
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        private WriterValidator _validator = new WriterValidator();
        private ValidationResult _validation;

        // GET: Writer
        [HttpGet]
        public ActionResult Index()
        {
            var result = _writerService.GetByEmail(Session["WriterEmail"].ToString());

            return View(result);
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
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
