using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class WriterLoginController : Controller
    {
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: WriterLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            var result = _writerService.GetAll();

            var user = result.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.WriterEmail, false);
                Session["WriterId"] = user.WriterId;
                Session["WriterId"] = user.WriterEmail;

                return RedirectToAction("Index", "WriterPanel");
            }

            return RedirectToAction("Index");
        }
    }
}
