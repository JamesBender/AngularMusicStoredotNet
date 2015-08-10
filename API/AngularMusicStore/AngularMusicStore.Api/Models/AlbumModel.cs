using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Services;
using AutoMapper;

namespace AngularMusicStore.Api.Models
{
    public interface IAlbumModel
    {
        Album GetAlbum(Guid albumId);
        IEnumerable<Album> GetAlbumsByArtist(Guid artistId);
        Guid Save(Guid artistId, Album album);
        void Delete(Guid albumId);
        IList<Album> GetByPartialName(string nameToFind);
        IList<Album> GetAlbums();
    }

    public class AlbumModel : IAlbumModel
    {
        private readonly IAlbumService _albumService;

        public AlbumModel(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public Album GetAlbum(Guid albumId)
        {
            var domainAlbum = _albumService.GetAlbum(albumId);
            if (domainAlbum == null)
            {
                throw new ArgumentNullException("albumId", "no such album");
            }
            return Mapper.Map<Core.Entities.Album, Album>(domainAlbum);
        }

        public IEnumerable<Album> GetAlbumsByArtist(Guid artistId)
        {
            var listOfDomainAlbums = _albumService.GetAlbumsByArtist(artistId);
            return listOfDomainAlbums.Select(Mapper.Map<Core.Entities.Album, Album>).ToList();
        }

        public Guid Save(Guid artistId, Album album)
        {
            var domainAlbum = Mapper.Map<Album, Core.Entities.Album>(album);
            return _albumService.Save(artistId, domainAlbum);
        }

        public void Delete(Guid albumId)
        {
            _albumService.Delete(albumId);
        }

        public IList<Album> GetByPartialName(string nameToFind)
        {
            var listOfAlbums = _albumService.FindByName(nameToFind);
            return listOfAlbums.Select(Mapper.Map<Core.Entities.Album, Album>).ToList();
        }

        public IList<Album> GetAlbums()
        {
            var listOfAlbums = _albumService.GetAlbums();
            return listOfAlbums.Select(Mapper.Map<Core.Entities.Album, Album>).ToList();
        }
    }
}