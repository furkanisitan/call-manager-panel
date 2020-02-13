using CallManagerPanel.Entities.Concrete;
using System.Collections.Generic;

namespace CallManagerPanel.Business.Abstract
{
    public interface ICallService
    {
        ICollection<Call> GetAllByContactIdWithUsers(int contactId);
        Call GetById(int id);
        Call Add(Call call);
        Call Update(Call call);
        void DeleteById(int id);
        int GetCountByContactId(int contactId);
    }
}
