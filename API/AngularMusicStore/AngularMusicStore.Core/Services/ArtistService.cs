using System;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public class ArtistService
    {
        private IRepository _artistRepository;

        public ArtistService(IRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public Artist GetById(Guid artistId)
        {
            return _artistRepository.GetById<Artist>(artistId);
        }
    }
}