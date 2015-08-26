using System.Configuration;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Domain.Artist, Artist>()
                .ForMember(m => m.PictureUrl, opt => opt.ResolveUsing<DomainArtistImageResolver>());
            Mapper.CreateMap<Artist, Domain.Artist>()
                .ForMember(m => m.PictureUrl, opt => opt.ResolveUsing<ApiAlbumImageResolver>());

            Mapper.CreateMap<Domain.Album, Album>()
                .ForMember(m => m.CoverUri, opt => opt.ResolveUsing<DomainAlbumImageResolver>());
            Mapper.CreateMap<Album, Domain.Album>();

            Mapper.CreateMap<Domain.Track, Track>();
            Mapper.CreateMap<Track, Domain.Track>();
        }
    }

    static class ImageResolverPath
    {
        public static string Path => ConfigurationManager.AppSettings["ImageBasePath"];
    }

    public class ApiAlbumImageResolver : ValueResolver<Artist, string>
    {
        protected override string ResolveCore(Artist source)
        {
            if (source.PictureUrl.IsNullOrWhiteSpace())
            {
                return "";
            }
            var url = source.PictureUrl;

            var baseImagePath = ImageResolverPath.Path + "Artist/";

            if (source.PictureUrl.Contains(baseImagePath))
            {
                var len = baseImagePath.Length;
                url = source.PictureUrl.Substring(len);
            }
            return url;
        }
    }
    public class DomainArtistImageResolver : ValueResolver<Domain.Artist, string>
    {
        protected override string ResolveCore(Domain.Artist source)
        {
            var baseImagePath = ConfigurationManager.AppSettings["ImageBasePath"];

            return $"{baseImagePath}Artist/{source.PictureUrl}";
        }
    }

    public class DomainAlbumImageResolver : ValueResolver<Domain.Album, string>
    {
        protected override string ResolveCore(Domain.Album source)
        {
            var baseImagePath = ConfigurationManager.AppSettings["ImageBasePath"];

            return $"{baseImagePath}Album/{source.CoverUri}";
        }
    }
}