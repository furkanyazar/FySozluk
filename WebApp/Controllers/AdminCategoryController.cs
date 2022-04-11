using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminCategoryController : Controller
    {
        private ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());

        private CategoryValidator _validator = new CategoryValidator();
        private ValidationResult _validation;

        // GET: AdminCategory
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var result = _categoryService.GetAll();

            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _validation = _validator.Validate(category);

            if (_validation.IsValid)
            {
                _categoryService.Add(category);

                return RedirectToAction("");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = _categoryService.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _validation = _validator.Validate(category);

            if (_validation.IsValid)
            {
                _categoryService.Update(category);

                return RedirectToAction("");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var result = _categoryService.GetById(id);
            result.CategoryStatus = result.CategoryStatus ? false : true;

            _categoryService.Update(result);

            return RedirectToAction("");
        }
    }
}
