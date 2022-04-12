using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using WebApp.Models;

namespace DataAccess.EntityFramework
{
    public class EfContentDal : Repository<Content, MvcDemoDbContext>, IContentDal
    {
    }
}
