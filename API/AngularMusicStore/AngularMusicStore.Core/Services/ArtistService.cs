using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public interface IArtistService
    {
        Artist GetById(Guid artistId);
        IEnumerable<Artist> GetAll();
        Guid Save(Artist artist);
        void Delete(Artist artist);
    }

    public class ArtistService : IArtistService
    {
        private readonly IRepository _artistRepository;

        public ArtistService(IRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public Artist GetById(Guid artistId)
        {
            return _artistRepository.GetById<Artist>(artistId);
        }

        public IEnumerable<Artist> GetAll()
        {
            return _artistRepository.GetAll<Artist>();
        }

        public Guid Save(Artist artist)
        {
            return _artistRepository.Save(artist);
        }

        public void Delete(Artist artist)
        {
            _artistRepository.Delete(artist);
        }
    }
}