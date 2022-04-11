using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class WriterHeadingController : Controller
    {
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        private HeadingValidator _validator = new HeadingValidator();
        private ValidationResult _validation;

        // GET: WriterHeading
        public ActionResult MyHeadings()
        {
            int writerId = (int)Session["WriterId"];

            var result = _headingService.GetAllByWriterId(writerId).Where(x => x.HeadingStatus).ToList();

            GetForeignValues(result);

            return View(result);
        }

        public ActionResult AllHeadings(int page = 1)
        {
            var result = _headingService.GetAll().OrderByDescending(x => x.HeadingDate).ToList();

            GetForeignValues(result);

            return View(result.ToPagedList(page, 10));
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            ViewBag.categories = GetCategoriesSelectListItems();

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.WriterId = (int)Session["WriterId"];

            _validation = _validator.Validate(heading);

            if (_validation.IsValid)
            {
                _headingService.Add(heading);
                return RedirectToAction("MyHeadings");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var result = _headingService.GetById(id);

            if (result.Category is null)
            {
                result.Category = _categoryService.GetById(result.CategoryId);
            }

            ViewBag.categories = GetCategoriesSelectListItems();

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            var oldHeading = _headingService.GetById(heading.HeadingId);
            heading.HeadingDate = oldHeading.HeadingDate;
            heading.WriterId = oldHeading.WriterId;

            _validation = _validator.Validate(heading);

            if (_validation.IsValid)
            {
                _headingService.Update(heading);
                return RedirectToAction("MyHeadings");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = _headingService.GetById(id);
            result.HeadingStatus = result.HeadingStatus ? false : true;
            _headingService.Update(result);

            return RedirectToAction("MyHeadings");
        }

        public void GetForeignValues(ICollection<Heading> result)
        {
            foreach (var item in result)
            {
                if (item.Category is null)
                {
                    item.Category = _categoryService.GetById(item.CategoryId);
                }

                if (item.Writer is null)
                {
                    item.Writer = _writerService.GetById(item.WriterId);
                }

                if (item.Writer.WriterImageUrl is null)
                {
                    item.Writer.WriterImageUrl = Defaults.DEFAULT_WRITER_IMAGE_URL;
                }
            }
        }

        public ICollection<SelectListItem> GetCategoriesSelectListItems()
        {
            return (from x in _categoryService.GetAll()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString()
                    }).ToList();
        }
    }
}
