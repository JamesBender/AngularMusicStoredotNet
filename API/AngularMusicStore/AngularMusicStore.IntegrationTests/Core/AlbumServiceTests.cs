using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Factories;
using AngularMusicStore.Core.Services;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests.Core
{
    [TestFixture]
    public class AlbumServiceTests
    {
        private IArtistService _artistService;
        private IAlbumService _albumService;

        [SetUp]
        public void SetupTests()
        {
            var kernel = new StandardKernel(new DomainModule());
            _artistService = kernel.Get<IArtistService>();
            _albumService = kernel.Get<IAlbumService>();
        }

        [Test]
        public void ShouldBeAbleToGetAnAlbumByAlbumId()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            var albumName = Guid.NewGuid().ToString();
            var albumReleaseDate = DateTime.Now;
            var albumCoverUrl = Guid.NewGuid().ToString();
            var album = new Album {Name = albumName, CoverUrl = albumCoverUrl, ReleaseDate = albumReleaseDate};
            artist.AddAlbum(album);

            var artistId = _artistService.Save(artist);

            Assert.IsNotNull(artistId);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(1, artist.Albums.Count);
            Assert.AreNotEqual(artist.Albums[0].Id, Guid.Empty);

            var albumId = artist.Albums[0].Id;

            album = _albumService.GetAlbum(albumId);

            Assert.IsNotNull(album);
            Assert.AreEqual(albumName, album.Name);
            Assert.AreEqual(albumCoverUrl, album.CoverUrl);

            _artistService.Delete(artist.Id);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAlbumsByArtistThatHasAlbums()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            var albumOne = new Album {Name = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now};
            var albumTwo = new Album {Name = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now};
            var albumThree = new Album {Name = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now};

            artist.AddAlbum(albumOne);
            artist.AddAlbum(albumTwo);
            artist.AddAlbum(albumThree);

            var artistId = _artistService.Save(artist);
            Assert.IsNotNull(artistId);

            var result = _albumService.GetAlbumsByArtist(artistId) as IList<Album>;
            
            Assert.IsNotNull(result);
            Assert.AreEqual(artist.Albums.Count, result.Count());
            Assert.IsNotNull(result.FirstOrDefault(x => x.Name == albumOne.Name));
            Assert.IsNotNull(result.FirstOrDefault(x => x.Name == albumTwo.Name));
            Assert.IsNotNull(result.FirstOrDefault(x => x.Name == albumThree.Name));

            _artistService.Delete(artist.Id);
        }

        [Test]
        public void ShouldBeAbleToGetAnEmptyListOfAlbumsByArtistThatHasNoAlbums()
        {
            var artist = new Artist { Name = Guid.NewGuid().ToString() };
                        
            var artistId = _artistService.Save(artist);
            Assert.IsNotNull(artistId);

            var result = _albumService.GetAlbumsByArtist(artistId) as IList<Album>;

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
            
            _artistService.Delete(artist.Id);
        }

        [Test]
        public void ShouldBeAbleToSaveANewAlbumForAValidArtist()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            var artistId = _artistService.Save(artist);

            var albumName = Guid.NewGuid().ToString();
            var albumCoverUrl = Guid.NewGuid().ToString();
            var newAlbum = new Album {Name = albumName, CoverUrl = albumCoverUrl, ReleaseDate = DateTime.Now};
            artist.AddAlbum(newAlbum);

            var albumId = _albumService.Save(artistId, newAlbum);

            Assert.IsNotNull(albumId);

            newAlbum = _albumService.GetAlbum(albumId);

            Assert.IsNotNull(newAlbum);
            Assert.AreEqual(albumName, newAlbum.Name);
            Assert.AreEqual(albumCoverUrl, newAlbum.CoverUrl);

            artist = _artistService.GetById(artistId);

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(1, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == albumName && x.CoverUrl == albumCoverUrl));

            _artistService.Delete(artist.Id);
        }
    }
}