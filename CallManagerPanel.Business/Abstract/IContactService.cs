using CallManagerPanel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CallManagerPanel.Business.Abstract
{
    public interface IContactService
    {
        ICollection<Contact> GetAll(Expression<Func<Contact, bool>> filter = null);
        Contact GetById(int id);
        Contact Add(Contact contact);
        Contact Update(Contact contact);
        void DeleteById(int id);
        bool IsPropertiesEdited(Contact contact, params string[] properties);
    }
}