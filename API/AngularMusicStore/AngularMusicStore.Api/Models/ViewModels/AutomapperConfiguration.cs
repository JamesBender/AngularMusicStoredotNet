using AutoMapper;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Domain.Artist, Artist>();
            Mapper.CreateMap<Artist, Domain.Artist>();
            Mapper.CreateMap<Domain.Album, Album>();
            Mapper.CreateMap<Album, Domain.Album>();
        }
    }
}