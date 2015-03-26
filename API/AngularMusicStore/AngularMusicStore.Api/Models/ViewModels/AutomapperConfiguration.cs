using System.Configuration;
using AutoMapper;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Domain.Artist, Artist>()
                .ForMember(m => m.PictureUrl, opt => opt.ResolveUsing<ImageResolver>());
            Mapper.CreateMap<Artist, Domain.Artist>();
            Mapper.CreateMap<Domain.Album, Album>();
            Mapper.CreateMap<Album, Domain.Album>();
        }
    }

    public class ImageResolver : ValueResolver<Domain.Artist, string>
    {
        protected override string ResolveCore(Domain.Artist source)
        {
            var baseImagePath = ConfigurationManager.AppSettings["ImageBasePath"];

            return baseImagePath + source.PictureUrl;
        }
    }
}