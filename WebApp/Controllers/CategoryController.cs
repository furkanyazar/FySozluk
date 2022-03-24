using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager manager = new CategoryManager(new EfCategoryDal());

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategories()
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
            manager.Add(category);
            return RedirectToAction("GetCategories");
        }
    }
}
