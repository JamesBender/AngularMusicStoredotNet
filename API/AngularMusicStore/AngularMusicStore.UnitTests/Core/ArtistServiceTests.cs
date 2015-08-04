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
    public class ArtistServiceTests
    {
        private ArtistService _artistService;
        private Mock<IRepository> _artistRepository;

        [SetUp]
        public void SetupTests()
        {
            _artistRepository = new Mock<IRepository>();
            _artistService = new ArtistService(_artistRepository.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAnArtistFromTheArtistService()
        {
            var artistId = Guid.NewGuid();
            _artistRepository.Setup(x => x.GetById<Artist>(artistId)).Returns(new Artist());

            var result = _artistService.GetById(artistId);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAllArtistsFromTheArtistService()
        {
            var listOfArtists = new List<Artist> { new Artist(), new Artist(), new Artist() };
            var numberOfArtists = listOfArtists.Count;
            _artistRepository.Setup(x => x.GetAll<Artist>()).Returns(listOfArtists);

            var result = _artistService.GetAll();

            Assert.AreEqual(numberOfArtists, result.ToList().Count);
        }

        [Test]
        public void ShouldBeAbleToSaveAnNewArtist()
        {
            var artist = new Artist();
            var artistId = Guid.NewGuid();
            _artistRepository.Setup(x => x.Save(artist)).Returns(artistId);

            var result = _artistService.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
        }

        [Test]
        public void ShouldBeAbleToUpdateAnExistingArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist { Id = artistId };
            _artistRepository.Setup(x => x.Save(artist)).Returns(artistId);

            var result = _artistService.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnExistingArtist()
        {
            var artist = new Artist { Id = Guid.NewGuid() };
            _artistRepository.Setup(x => x.GetById<Artist>(artist.Id)).Returns(artist);

            _artistService.Delete(artist.Id);

            _artistRepository.Verify(x => x.Delete(artist), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(DataNotFoundException))]
        public void ShouldGetADataNotFoundExceptionWhenTryingToDeleteAnArtistThatDoesntExist()
        {
            var artistId = Guid.NewGuid();
            try
            {
                _artistService.Delete(artistId);
            }
            catch (DataNotFoundException exception)
            {
                Assert.AreEqual(string.Format("Artist {0} not found.", artistId), exception.Message);
                throw;
            }
        }

        [Test]
        public void ShouldBeAbleToFindAnArtistByName()
        {
            const string nameToFind = "Bob";
            
            var artistToFind = new Artist {Name = nameToFind};
            var listOfFoundArtists = new List<Artist>{artistToFind};
            
            _artistRepository.Setup(x => x.SearchByName<Artist>(nameToFind))
                .Returns(listOfFoundArtists);
            
            var result = _artistService.FindByName(nameToFind);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ToList().Count);
            Assert.IsNotNull(result.FirstOrDefault(x => x.Name == nameToFind));
        }
    }
}