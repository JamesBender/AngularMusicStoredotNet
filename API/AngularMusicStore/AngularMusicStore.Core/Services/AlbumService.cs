using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Exceptions;
using AngularMusicStore.Core.Persistence;

namespace AngularMusicStore.Core.Services
{
    public interface IAlbumService
    {
        Album GetAlbum(Guid albumId);
        IEnumerable<Album> GetAlbumsByArtist(Guid artistId);
        Guid Save(Guid artistId, Album album);
        void Delete(Guid albumId);
        IEnumerable<Album> FindByName(string nameToFind);
    }

    public class AlbumService : IAlbumService
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

        public void Delete(Guid albumId)
        {
            var album = _repository.GetById<Album>(albumId);
            if (album == null)
            {
                throw new DataNotFoundException(string.Format("Album {0} not found.", albumId));
            }
            _repository.Delete(album);
        }

        public IEnumerable<Album> FindByName(string nameToFind)
        {
            return _repository.SearchByName<Album>(nameToFind);
        }
    }
}