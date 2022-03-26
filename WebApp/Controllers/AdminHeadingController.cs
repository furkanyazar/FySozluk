using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminHeadingController : Controller
    {
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());

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
            }

            return View(result);
        }
    }
}
