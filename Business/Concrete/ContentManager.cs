using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.GetAll(x => x.HeadingId == id);
        }

        public List<Content> GetAllBySearchKey(string key)
        {
            return _contentDal.GetAll(x => x.ContentText.Contains(key));
        }

        public List<Content> GetAllByWriterId(int id)
        {
            return _contentDal.GetAll(x => x.WriterId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
