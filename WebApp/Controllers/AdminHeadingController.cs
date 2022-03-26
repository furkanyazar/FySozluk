using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminHeadingController : Controller
    {
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: AdminHeading
        public ActionResult Index()
        {
            var result = _headingService.GetAll();

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
            }

            return View(result);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            List<SelectListItem> writers = (from x in _writerService.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterFirstName + " " + x.WriterLastName,
                                                Value = x.WriterId.ToString()
                                            }).ToList();

            ViewBag.categories = categories;
            ViewBag.writers = writers;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Today;

            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);

            if (result.IsValid)
            {
                _headingService.Add(heading);
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
