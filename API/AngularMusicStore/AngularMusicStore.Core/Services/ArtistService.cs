using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Exceptions;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public interface IArtistService
    {
        Artist GetById(Guid artistId);
        IEnumerable<Artist> GetAll();
        Guid Save(Artist artist);
        void Delete(Guid artistId);
        IEnumerable<Artist> FindByName(string nameToFind);
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
            return _artistRepository.GetAll<Artist>().OrderBy(x => x.Name).ToList();
        }

        public Guid Save(Artist artist)
        {
            return _artistRepository.Save(artist);
        }

        public void Delete(Guid artistId)
        {
            var artist = _artistRepository.GetById<Artist>(artistId);
            if (artist == null)
            {
                throw new DataNotFoundException(string.Format("Artist {0} not found.", artistId));
            }
            _artistRepository.Delete(artist);
        }

        public IEnumerable<Artist> FindByName(string nameToFind)
        {
            return _artistRepository.SearchByName<Artist>(nameToFind).OrderBy(x => x.Name).ToList();
        }
    }
}