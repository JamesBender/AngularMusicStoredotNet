using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Exceptions;
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
            var trackName = Guid.NewGuid().ToString();
            var trackOrder = 1;
            var trackLength = new TimeSpan(0,4,27);
            var trackRating = 3;
            var trackId = Guid.NewGuid();

            var track = new Track
            {
                AlbumOrder = trackOrder,
                Id = trackId,
                Length = trackLength,
                Name = trackName,
                Rating = trackRating
            };

            var albumName = Guid.NewGuid().ToString();
            var albumCoverUrl = Guid.NewGuid().ToString();
            var albumReleaseDate = DateTime.Now;
            var albumId = Guid.NewGuid();
            var album = new Album {Name = albumName, CoverUri = albumCoverUrl, ReleaseDate = albumReleaseDate};
            album.AddTrack(track);

            _repository.Setup(x => x.GetById<Album>(albumId)).Returns(album);
            
            var result = _albumService.GetAlbum(albumId);

            Assert.IsNotNull(result);
            Assert.AreEqual(albumName, result.Name);
            Assert.AreEqual(albumCoverUrl, result.CoverUri);
            Assert.AreEqual(albumReleaseDate, result.ReleaseDate);

            Assert.IsNotNull(result.Tracks);
            Assert.AreEqual(1, result.Tracks.Count);
            Assert.AreEqual(result.Tracks[0].AlbumOrder, trackOrder);
            Assert.AreEqual(result.Tracks[0].Id, trackId);
            Assert.AreEqual(result.Tracks[0].Length, trackLength);
            Assert.AreEqual(result.Tracks[0].Name, trackName);
            Assert.AreEqual(result.Tracks[0].Rating, trackRating);

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
            var album = new Album {Id = Guid.NewGuid()};
            _repository.Setup(x => x.GetById<Album>(album.Id)).Returns(album);

            _albumService.Delete(album.Id);

            _repository.Verify(x => x.Delete(album), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(DataNotFoundException))]
        public void ShouldGetADataNotFoundExceptionWhenTryingToDeleteAnAlbumThatDoesntExist()
        {
            var albumId = Guid.NewGuid();
            try
            {
                _albumService.Delete(albumId);
            }
            catch (DataNotFoundException exception)
            {
                Assert.AreEqual($"Album {albumId} not found.", exception.Message);
                throw;
            }
        }

        [Test]
        public void ShouldBeAbleToFindAnAlbumsByName()
        {
            const string nameToFind = "Bob";

            var albumToFind = new Album { Name = nameToFind };
            var listOfFoundAlbums = new List<Album> { albumToFind };

            _repository.Setup(x => x.SearchByName<Album>(nameToFind))
                .Returns(listOfFoundAlbums);

            var result = _albumService.FindByName(nameToFind);

            Assert.IsNotNull(result);
            var enumerable = result as Album[] ?? result.ToArray();
            Assert.AreEqual(1, enumerable.ToList().Count);
            Assert.IsNotNull(enumerable.FirstOrDefault(x => x.Name == nameToFind));
        }
    }
}