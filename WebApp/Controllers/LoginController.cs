using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IAdminService _adminService = new AdminManager(new EfAdminDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        private WriterValidator _validator = new WriterValidator();
        private ValidationResult _validation;

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            writer.WriterPassword = HashingHelper.PasswordHash(writer.WriterPassword);

            var result = _writerService.GetAll();

            var user = result.SingleOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.WriterEmail, false);

                Session["WriterId"] = user.WriterId;
                Session["WriterEmail"] = user.WriterEmail;
                Session["WriterFirstName"] = user.WriterFirstName;
                Session["WriterLastName"] = user.WriterLastName;
                Session["WriterImageUrl"] = user.WriterImageUrl;

                return RedirectToAction("Index", "WriterPanel");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Writer writer)
        {
            _validation = _validator.Validate(writer);

            if (_validation.IsValid)
            {
                writer.WriterPassword = HashingHelper.PasswordHash(writer.WriterPassword);

                _writerService.Add(writer);

                return RedirectToAction("Index");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            admin.AdminPassword = HashingHelper.PasswordHash(admin.AdminPassword);

            var result = _adminService.GetAll();

            var user = result.SingleOrDefault(x => x.AdminEmail == admin.AdminEmail && x.AdminPassword == admin.AdminPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.AdminEmail, false);

                Session["AdminId"] = user.AdminId;
                Session["AdminEmail"] = user.AdminEmail;
                Session["AdminRole"] = user.AdminRole;
                Session["AdminFirstName"] = user.AdminFirstName;
                Session["AdminLastName"] = user.AdminLastName;

                return RedirectToAction("Index", "AdminContent");
            }

            return RedirectToAction("Admin");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Headings", "Default");
        }
    }
}
