using CallManagerPanel.Business.Abstract;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace CallManagerPanel.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUsernamePassword(string username, string password, bool isIncludeRoles = false)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Expression<Func<User, bool>> filter = x => x.Username.Equals(username) && x.Password.Equals(password);
            return isIncludeRoles ? _userDal.GetWithRoles(filter) : _userDal.Get(filter);
        }

        public User GetByIdWithRoles(int id) =>
            _userDal.GetWithRoles(x => x.Id == id);
    }
}
