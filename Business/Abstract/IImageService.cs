using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImageService
    {
        List<Image> GetAll();

        Image GetById(int id);

        void Add(Image image);

        void Delete(Image image);

        void Update(Image image);
    }
}
