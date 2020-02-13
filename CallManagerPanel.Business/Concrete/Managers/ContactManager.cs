using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Business.ValidationRules.FluentValidation;
using CallManagerPanel.Core.Aspects.Postsharp.AuthorizationAspects;
using CallManagerPanel.Core.Aspects.Postsharp.ValidationAspects;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CallManagerPanel.Business.Concrete.Managers
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public ICollection<Contact> GetAll(Expression<Func<Contact, bool>> filter = null) =>
            _contactDal.GetAll(filter);

        public Contact GetById(int id) =>
            _contactDal.Get(x => x.Id == id);

        [FluentValidationAspect(typeof(ContactValidator))]
        public Contact Add(Contact contact)
        {
            contact.UserId = PrincipalHelper.GetId();
            return _contactDal.Add(contact);
        }

        [FluentValidationAspect(typeof(ContactValidator), "default,update")]
        public Contact Update(Contact contact)
        {
            contact.UserId = PrincipalHelper.GetId();
            return _contactDal.Update(contact);
        }

        [AuthorizationAspect("Admin", "Manager")]
        public void DeleteById(int id) =>
            _contactDal.Delete(new Contact { Id = id });

        public bool IsPropertiesEdited(Contact contact, params string[] properties) =>
            _contactDal.IsPropertiesEdited(contact, properties);
    }
}