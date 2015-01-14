using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;
using NHibernate;
using Ninject.Modules;

namespace AngularMusicStore.Core.Factories
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            Bind<IRepository<Artist>>().To<Repository<Artist>>();
        }
    }
}