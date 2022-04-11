using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryForChart> BlogList()
        {
            List<CategoryForChart> categoryForCharts = new List<CategoryForChart>();

            categoryForCharts.AddRange(new List<CategoryForChart>
            {
                new CategoryForChart
                {
                    CategoryName = "Yazılım",
                    CategoryCount = 8
                },
                new CategoryForChart
                {
                    CategoryName = "Seyahat",
                    CategoryCount = 4
                },
                new CategoryForChart
                {
                    CategoryName = "Teknoloji",
                    CategoryCount = 7
                },
                new CategoryForChart
                {
                    CategoryName = "Spor",
                    CategoryCount = 1
                }
            });

            return categoryForCharts;
        }
    }
}
