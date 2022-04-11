using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.IO;
using System.Web.Mvc;
using WebApp.Helpers;

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
                writer.WriterPassword = Defaults.PASSWORD_HASH_KEY;
            }

            _validation = _validator.Validate(writer);

            if (_validation.IsValid)
            {
                if (Request.Files["WriterImage"].ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Images/profiles/" + fileName + extension;

                    Request.Files[0].SaveAs(Server.MapPath(path));

                    writer.WriterImageUrl = "/Images/profiles/" + fileName + extension;
                }

                if (writer.WriterPassword == Defaults.PASSWORD_HASH_KEY)
                {
                    writer.WriterPassword = _writerService.GetById(writer.WriterId).WriterPassword;
                }
                else
                {
                    writer.WriterPassword = HashingHelper.PasswordHash(writer.WriterPassword);
                }

                _writerService.Update(writer);

                return RedirectToAction("");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
