using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Business.ValidationRules.FluentValidation;
using CallManagerPanel.Core.Aspects.Postsharp.AuthorizationAspects;
using CallManagerPanel.Core.Aspects.Postsharp.ValidationAspects;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.Entities.Concrete;
using System.Collections.Generic;

namespace CallManagerPanel.Business.Concrete.Managers
{
    public class CallManager : ICallService
    {
        private readonly ICallDal _callDal;

        public CallManager(ICallDal callDal)
        {
            _callDal = callDal;
        }
        public ICollection<Call> GetAllByContactIdWithUsers(int contactId) =>
            _callDal.GetAllWithUsers(x => x.ContactId == contactId);

        public Call GetById(int id) =>
            _callDal.Get(x => x.Id == id);

        [FluentValidationAspect(typeof(CallValidator), "default,create")]
        public Call Add(Call call)
        {
            call.UserId = PrincipalHelper.GetId();
            return _callDal.Add(call);
        }

        [FluentValidationAspect(typeof(CallValidator))]
        public Call Update(Call call)
        {
            call.UserId = PrincipalHelper.GetId();
            return _callDal.Update(call);
        }

        [AuthorizationAspect("Admin", "Manager")]
        public void DeleteById(int id) =>
            _callDal.Delete(new Call { Id = id });

        public int GetCountByContactId(int contactId) =>
            _callDal.GetCount(x => x.ContactId == contactId);
    }
}