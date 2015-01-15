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
            var listOfArtists = new List<Artist> {new Artist(), new Artist(), new Artist()};
            var numberOfArtists = listOfArtists.Count;
            _artistRepository.Setup(x => x.GetAll<Artist>()).Returns(listOfArtists);

            var result = _artistService.GetAll();

            Assert.AreEqual(numberOfArtists, result.ToList().Count);
        }
    }
}