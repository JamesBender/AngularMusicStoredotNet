using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;
using AngularMusicStore.Core.Services;
using Moq;
using NUnit.Framework;

namespace AngularMusicStore.UnitTests.Core
{
    [TestFixture]
    public class AlbumServiceTests
    {
        private Mock<IRepository> _repository;
        private AlbumService _albumService;
        private Mock<IArtistService> _artistService;

        [SetUp]
        public void SetupTests()
        {
            _repository = new Mock<IRepository>();
            _artistService = new Mock<IArtistService>();
            _albumService = new AlbumService(_repository.Object, _artistService.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAnAlbumById()
        {
            var albumName = Guid.NewGuid().ToString();
            var albumCoverUrl = Guid.NewGuid().ToString();
            var albumReleaseDate = DateTime.Now;
            var albumId = Guid.NewGuid();
            
            _repository.Setup(x => x.GetById<Album>(albumId))
                .Returns(new Album {Name = albumName, CoverUrl = albumCoverUrl, ReleaseDate = albumReleaseDate});
            
            var result = _albumService.GetAlbum(albumId);

            Assert.IsNotNull(result);
            Assert.AreEqual(albumName, result.Name);
            Assert.AreEqual(albumCoverUrl, result.CoverUrl);
            Assert.AreEqual(albumReleaseDate, result.ReleaseDate);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAlbumsByArtistIdWhereThatArtistHasAlbums()
        {
            var albumOne = new Album();
            var albumTwo = new Album();
            var albumThree = new Album();
            var listOfAlbums = new List<Album> {albumOne, albumTwo, albumThree};
            var artistId = Guid.NewGuid();
            var artist = new Artist();
            artist.AddAlbum(albumOne);
            artist.AddAlbum(albumTwo);
            artist.AddAlbum(albumThree);
            _artistService.Setup(x => x.GetById(artistId)).Returns(artist);

            var result = _albumService.GetAlbumsByArtist(artistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(listOfAlbums.Count, result.Count());
        }

        [Test]
        public void ShouldGetAnEmptyListOfAlbumsForAnArtistThatHasNoAlbums()
        {
            var artistId = Guid.NewGuid();
            _artistService.Setup(x => x.GetById(artistId)).Returns(new Artist());

            var result = _albumService.GetAlbumsByArtist(artistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void ShouldBeAbleToSaveAnAlbumWithAValidArtistId()
        {
            var artistId = Guid.NewGuid();
            var albumId = Guid.NewGuid();
            var album = new Album();

            _artistService.Setup(x => x.GetById(artistId)).Returns(new Artist());
            _repository.Setup(x => x.Save(album)).Returns(albumId);

            var result = _albumService.Save(artistId, album);

            Assert.IsNotNull(result);
            Assert.AreEqual(albumId, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldNotBeAbleToSaveAnAlbumWithAnInvalidArtistId()
        {
            var artistId = Guid.NewGuid();
            var album = new Album();

            _albumService.Save(artistId, album);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnAlbum()
        {
            var album = new Album();

            _albumService.Delete(album);

            _repository.Verify(x => x.Delete(album), Times.Once);
        }
    }
}