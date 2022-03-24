using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager
    {
        private Repository<Category, Context> repository = new Repository<Category, Context>();

        public List<Category> GetAll()
        {
            return repository.GetAll();
        }

        public void Add(Category category)
        {
            if (category.CategoryName == "" || category.CategoryName.Length < 3 || category.CategoryName.Length > 50 || category.CategoryDescription == "")
            {
                // error message
            }
            else
            {
                repository.Add(category);
            }
        }
    }
}
