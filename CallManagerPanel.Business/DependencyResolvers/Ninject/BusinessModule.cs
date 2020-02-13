using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Business.Concrete.Managers;
using CallManagerPanel.DataAccess.Abstract;
using CallManagerPanel.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace CallManagerPanel.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Bind<IContactDal>().To<EfContactDal>().InSingletonScope();

            Bind<ICallService>().To<CallManager>().InSingletonScope();
            Bind<ICallDal>().To<EfCallDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();
        }
    }
}
