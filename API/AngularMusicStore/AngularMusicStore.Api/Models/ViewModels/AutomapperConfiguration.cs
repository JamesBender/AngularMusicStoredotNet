using System.Configuration;
using System.Drawing;
using AutoMapper;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Domain.Artist, Artist>()
                .ForMember(m => m.PictureUrl, opt => opt.ResolveUsing<ArtistImageResolver>());
            Mapper.CreateMap<Artist, Domain.Artist>();
            Mapper.CreateMap<Domain.Album, Album>()
                .ForMember(m => m.CoverUri, opt => opt.ResolveUsing<AlbumImageResolver>());
            Mapper.CreateMap<Album, Domain.Album>();
        }
    }

    public class ArtistImageResolver : ValueResolver<Domain.Artist, string>
    {
        protected override string ResolveCore(Domain.Artist source)
        {
            var baseImagePath = ConfigurationManager.AppSettings["ImageBasePath"];

            return $"{baseImagePath}Artist/{source.PictureUrl}";
        }
    }

    public class AlbumImageResolver : ValueResolver<Domain.Album, string>
    {
        protected override string ResolveCore(Domain.Album source)
        {
            var baseImagePath = ConfigurationManager.AppSettings["ImageBasePath"];

            return $"{baseImagePath}Album/{source.CoverUri}";
        }
    }
}