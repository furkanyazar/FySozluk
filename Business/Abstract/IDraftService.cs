using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetAll();

        List<Draft> GetAllOfReceivedByEmail(string email);

        List<Draft> GetAllOfSentByEmail(string email);

        Draft GetById(int id);

        void Add(Draft draft);

        void Delete(Draft draft);

        void Update(Draft draft);
    }
}
