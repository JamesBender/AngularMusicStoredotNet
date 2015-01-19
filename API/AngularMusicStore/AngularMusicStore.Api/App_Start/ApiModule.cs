using AngularMusicStore.Api.Models;

namespace AngularMusicStore.Api
{
    public class ApiModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IArtistModel>().To<ArtistModel>();
        }
    }
}