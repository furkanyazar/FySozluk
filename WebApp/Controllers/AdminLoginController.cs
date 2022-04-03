using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class AdminLoginController : Controller
    {
        private IAdminService _adminService = new AdminManager(new EfAdminDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = _adminService.GetAll();

            var user = result.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.AdminUserName, false);
                Session["AdminUserName"] = user.AdminUserName;
                Session["AdminPassword"] = user.AdminPassword;
                Session["AdminRole"] = user.AdminRole;

                return RedirectToAction("Index", "AdminCategory");
            }

            return RedirectToAction("Index");
        }
    }
}
