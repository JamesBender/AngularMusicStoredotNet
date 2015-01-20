using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public class AlbumService
    {
        private readonly IRepository _repository;
        private readonly IArtistService _artistService;

        public AlbumService(IRepository repository, IArtistService artistService)
        {
            _repository = repository;
            _artistService = artistService;
        }

        public Album GetAlbum(Guid albumId)
        {
            return _repository.GetById<Album>(albumId);
        }

        public IEnumerable<Album> GetAlbumsByArtist(Guid artistId)
        {
            var artist = _artistService.GetById(artistId);
            return artist.Albums;
        }

        public Guid Save(Guid artistId, Album album)
        {
            var artist = _artistService.GetById(artistId);
            if (artist == null)
            {
                throw new ArgumentNullException("artistId", string.Format("No artist exists for id {0}", artistId));
            }
            artist.AddAlbum(album);
            return _repository.Save(album);
        }

        public void Delete(Album album)
        {
            _repository.Delete(album);
        }
    }
}