using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using WebApp.Models;

namespace DataAccess.EntityFramework
{
    public class EfAdminDal : Repository<Admin, MvcDemoDbContext>, IAdminDal
    {
    }
}
