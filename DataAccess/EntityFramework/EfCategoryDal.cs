using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using WebApp.Models;

namespace DataAccess.EntityFramework
{
    public class EfCategoryDal : Repository<Category, MvcDemoDbContext>, ICategoryDal
    {
    }
}
