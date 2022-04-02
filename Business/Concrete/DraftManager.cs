using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DraftManager : IDraftService
    {
        private IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void Add(Draft draft)
        {
            _draftDal.Add(draft);
        }

        public void Delete(Draft draft)
        {
            _draftDal.Delete(draft);
        }

        public List<Draft> GetAll()
        {
            return _draftDal.GetAll();
        }

        public List<Draft> GetAllOfReceivedByEmail(string email)
        {
            return _draftDal.GetAll(x => x.ReceiverEmail == email);
        }

        public List<Draft> GetAllOfSentByEmail(string email)
        {
            return _draftDal.GetAll(x => x.SenderEmail == email);
        }

        public Draft GetById(int id)
        {
            return _draftDal.Get(x => x.DraftId == id);
        }

        public void Update(Draft draft)
        {
            _draftDal.Update(draft);
        }
    }
}
