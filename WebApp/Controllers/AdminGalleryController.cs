using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminGalleryController : Controller
    {
        private IImageService _imageService = new ImageManager(new EfImageDal());

        // GET: Gallery
        public ActionResult Index()
        {
            var result = _imageService.GetAll();

            return View(result);
        }
    }
}
