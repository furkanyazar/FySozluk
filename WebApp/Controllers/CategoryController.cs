using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager manager = new CategoryManager();

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
    }
}
