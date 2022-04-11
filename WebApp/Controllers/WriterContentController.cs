using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class WriterContentController : Controller
    {
        private IContentService _contentService = new ContentManager(new EfContentDal());
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        private ContentValidator _validator = new ContentValidator();
        private ValidationResult _validation;

        // GET: WriterContent
        public ActionResult Index()
        {
            int writerId = (int)Session["WriterId"];

            var result = _contentService.GetAllByWriterId(writerId).OrderByDescending(x => x.ContentDate).ToList();

            GetForeignValues(result);

            return View(result);
        }

        public ActionResult ContentsByHeading(int id)
        {
            int writerId = (int)Session["WriterId"];

            var result = _contentService.GetAllByHeadingId(id).Where(x => x.WriterId == writerId).OrderByDescending(x => x.ContentDate).ToList();

            GetForeignValues(result);

            return View(result);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;

            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.WriterId = (int)Session["WriterId"];

            _validation = _validator.Validate(content);

            if (_validation.IsValid)
            {
                _contentService.Add(content);

                return RedirectToAction("");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public void GetForeignValues(ICollection<Content> result)
        {
            foreach (var item in result)
            {
                if (item.Heading is null)
                {
                    item.Heading = _headingService.GetById(item.HeadingId);
                }

                if (item.Writer is null)
                {
                    item.Writer = _writerService.GetById((int)item.WriterId);
                }
            }
        }
    }
}
