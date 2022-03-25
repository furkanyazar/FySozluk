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
        private CategoryManager manager = new CategoryManager(new EfCategoryDal());

        // GET: AdminCategory
        public ActionResult Index()
        {
            var result = manager.GetAll();

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
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);

            if (result.IsValid)
            {
                manager.Add(category);
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var result = manager.GetById(id);
            manager.Delete(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = manager.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);

            if (result.IsValid)
            {
                manager.Update(category);
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
