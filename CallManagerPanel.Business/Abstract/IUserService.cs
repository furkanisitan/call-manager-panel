using CallManagerPanel.Entities.Concrete;
using System.Collections.Generic;

namespace CallManagerPanel.Business.Abstract
{
    public interface IUserService
    {
        User GetByUsernamePassword(string username, string password, bool isIncludeRoles = false);
        User GetByIdWithRoles(int id);

    }
}
