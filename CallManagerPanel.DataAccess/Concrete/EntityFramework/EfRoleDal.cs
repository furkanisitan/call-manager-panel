using CallManagerPanel.Core.DataAccess.EntityFramework;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.DataAccess.Concrete.EntityFramework.Configuration;
using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, CallManagerPanelContext>, IRoleDal
    {
    }
}