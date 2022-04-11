using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private IContentService _contentService = new ContentManager(new EfContentDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: Default
        public ActionResult Headings()
        {
            var result = _headingService.GetAll();

            return View(result);
        }

        public PartialViewResult Index(int id = 0)
        {
            var result = id == 0 ? _contentService.GetAll().OrderByDescending(x => x.ContentDate).ToList() : _contentService.GetAllByHeadingId(id).OrderByDescending(x => x.ContentDate).ToList();

            GetForeignValues(result);

            return PartialView(result);
        }

        public void GetForeignValues(ICollection<Content> result)
        {
            foreach (var item in result)
            {
                if (item.Heading is null)
                {
                    item.Heading = _headingService.GetById(item.HeadingId);
                }

                if (item.Writer is null)
                {
                    item.Writer = _writerService.GetById((int)item.WriterId);
                }
            }
        }
    }
}
