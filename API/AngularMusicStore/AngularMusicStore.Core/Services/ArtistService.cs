using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public class ArtistService
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
    }
}