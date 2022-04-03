using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfImageDal : Repository<Image, Context>, IImageDal
    {
    }
}
