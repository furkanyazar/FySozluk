using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminWriterController : Controller
    {
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: Writer
        public ActionResult Index()
        {
            var result = _writerService.GetAll();

            return View(result);
        }
    }
}
