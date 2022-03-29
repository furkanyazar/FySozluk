using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetAllByCategoryId(int id)
        {
            return _headingDal.GetAll(x => x.CategoryId == id);
        }

        public List<Heading> GetAllByWriterId(int id)
        {
            return _headingDal.GetAll(x => x.WriterId == id);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
