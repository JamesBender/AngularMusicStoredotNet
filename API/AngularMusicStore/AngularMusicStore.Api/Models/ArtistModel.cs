using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Services;
using AutoMapper;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models
{
    public interface IArtistModel
    {
        IEnumerable<Artist> GetArtists();
        Artist GetById(Guid artistId);
        Guid Save(Artist artist);
        void Delete(Guid artistId);
        IList<Artist> GetByPartialName(string nameToFind);
    }

    public class ArtistModel : IArtistModel
    {
        private readonly IArtistService _artistService;
        private string _imageBasePath;

        public ArtistModel(IArtistService artistService)
        {
            _artistService = artistService;
            _imageBasePath = ConfigurationManager.AppSettings["ImageBasePath"];
        }

        public IEnumerable<Artist> GetArtists()
        {
            var listOfDomainArtist = _artistService.GetAll();

            return listOfDomainArtist.Select(Mapper.Map<Domain.Artist, Artist>).ToList();
        }

        public Artist GetById(Guid artistId)
        {
            return Mapper.Map<Domain.Artist, Artist>(_artistService.GetById(artistId));
        }

        public Guid Save(Artist artist)
        {
            return _artistService.Save(Mapper.Map<Artist, Domain.Artist>(artist));
        }

        public void Delete(Guid artistId)
        {
            _artistService.Delete(artistId);
        }

        public IList<Artist> GetByPartialName(string nameToFind)
        {
            var listOfArtists = _artistService.FindByName(nameToFind);
            return listOfArtists.Select(Mapper.Map<Domain.Artist, Artist>).ToList();
        }
    }
}