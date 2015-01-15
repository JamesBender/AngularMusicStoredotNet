using AngularMusicStore.Core.Persistence;
using AngularMusicStore.Core.Services;
using NHibernate;
using Ninject.Modules;

namespace AngularMusicStore.Core.Factories
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            Bind<IRepository>().To<Repository>();
            Bind<IArtistService>().To<ArtistService>();
        }
    }
}