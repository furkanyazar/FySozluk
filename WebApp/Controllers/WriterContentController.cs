﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class WriterContentController : Controller
    {
        private IContentService _contentService = new ContentManager(new EfContentDal());
        private IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private IWriterService _writerService = new WriterManager(new EfWriterDal());

        // GET: WriterContent
        public ActionResult Index()
        {
            int writerId = _writerService.GetByEmail(Session["WriterEmail"].ToString()).WriterId;

            var result = _contentService.GetAllByWriterId(writerId).OrderByDescending(x => x.ContentDate).ToList();

            GetForeignValues(result);

            return View(result);
        }

        public ActionResult ContentsByHeading(int id)
        {
            int writerId = _writerService.GetByEmail(Session["WriterEmail"].ToString()).WriterId;

            var result = _contentService.GetAllByHeadingId(id).Where(x => x.WriterId == writerId).OrderByDescending(x => x.ContentDate).ToList();

            GetForeignValues(result);

            return View(result);
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
