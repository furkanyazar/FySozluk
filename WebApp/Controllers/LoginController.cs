using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IAdminService _adminService = new AdminManager(new EfAdminDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: Login
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
                Session["WriterEmail"] = user.WriterEmail;

                return RedirectToAction("Index", "WriterPanel");
            }

            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            var result = _adminService.GetAll();

            var user = result.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.AdminUserName, false);
                Session["AdminUserName"] = user.AdminUserName;
                Session["AdminRole"] = user.AdminRole;

                return RedirectToAction("Index", "AdminContent");
            }

            return RedirectToAction("Admin");
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("");
        }
    }
}
