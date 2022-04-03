using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Add(Image image)
        {
            _imageDal.Add(image);
        }

        public void Delete(Image image)
        {
            _imageDal.Delete(image);
        }

        public List<Image> GetAll()
        {
            return _imageDal.GetAll();
        }

        public Image GetById(int id)
        {
            return _imageDal.Get(x => x.ImageId == id);
        }

        public void Update(Image image)
        {
            _imageDal.Update(image);
        }
    }
}
