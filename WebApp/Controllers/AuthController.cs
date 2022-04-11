using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private IAdminService _adminService = new AdminManager(new EfAdminDal());

        // GET: Auth
        public ActionResult Index()
        {
            var result = _adminService.GetAll();

            return View(result);
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var result = _adminService.GetById(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            if (admin.AdminPassword is null)
            {
                admin.AdminPassword = _adminService.GetById(admin.AdminId).AdminPassword;
            }
            else
            {
                admin.AdminPassword = HashingHelper.PasswordHash(admin.AdminPassword);
            }

            _adminService.Update(admin);

            return RedirectToAction("");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = _adminService.GetById(id);
            result.AdminStatus = result.AdminStatus ? false : true;
            _adminService.Update(result);

            return RedirectToAction("");
        }
    }
}
