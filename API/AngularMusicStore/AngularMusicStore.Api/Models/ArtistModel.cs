using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Persistence;
using AutoMapper;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.Api.Models
{
    public interface IArtistModel
    {
        IEnumerable<Artist> GetArtists();
        Artist GetById(Guid artistId);
        Guid Save(Artist artist);
        void Delete(Artist artist);
    }

    public class ArtistModel : IArtistModel
    {
        private readonly IRepository _repository;

        public ArtistModel(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Artist> GetArtists()
        {
            var listOfDomainArtist = _repository.GetAll<Domain.Artist>();

            return listOfDomainArtist.Select(Mapper.Map<Domain.Artist, Artist>).ToList();
        }

        public Artist GetById(Guid artistId)
        {
            return Mapper.Map<Domain.Artist, Artist>(_repository.GetById<Domain.Artist>(artistId));
        }

        public Guid Save(Artist artist)
        {
            return _repository.Save(Mapper.Map<Artist, Domain.Artist>(artist));
        }

        public void Delete(Artist artist)
        {
            _repository.Delete(Mapper.Map<Artist, Domain.Artist>(artist));
        }
    }
}