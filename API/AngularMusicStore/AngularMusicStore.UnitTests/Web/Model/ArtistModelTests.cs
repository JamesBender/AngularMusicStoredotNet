using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Core.Persistence;
using Moq;
using NUnit.Framework;
using Domain = AngularMusicStore.Core.Entities;
using ApiModel = AngularMusicStore.Api.Models.ViewModels;

namespace AngularMusicStore.UnitTests.Web.Model
{
    [TestFixture]
    public class ArtistModelTests
    {
        private Mock<IRepository> _repository;
        private ArtistModel _artistModel;

        [SetUp]
        public void SetupTests()
        {
            ApiModel.AutomapperConfiguration.Configure();
            _repository = new Mock<IRepository>();
            _artistModel = new ArtistModel(_repository.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfArtistsFromTheArtistModel()
        {
            var listOfDomainArtists = new List<Domain.Artist> {new Domain.Artist(), new Domain.Artist()};
            _repository.Setup(x => x.GetAll<Domain.Artist>()).Returns(listOfDomainArtists);
            
            var result = _artistModel.GetArtists();

            Assert.IsNotNull(result);
            Assert.AreEqual(listOfDomainArtists.Count, result.Count());
        }

        [Test]
        public void ShouldBeAbleToGetASpecificArtistFromTheArtistModel()
        {
            var artistId = Guid.NewGuid();
            _repository.Setup(x => x.GetById<Domain.Artist>(artistId)).Returns(new Domain.Artist());

            var result = _artistModel.GetById(artistId);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToSaveANewArtist()
        {
            var artist = new ApiModel.Artist();

            var result = _artistModel.Save(artist);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToSaveAnExistingArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new ApiModel.Artist {Id = artistId};
            _repository.Setup(x => x.Save(It.IsAny<Domain.Artist>())).Returns(artistId);

            var result = _artistModel.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnExistingArtist()
        {
            var artist = new ApiModel.Artist();

            _artistModel.Delete(artist);

            _repository.Verify(x => x.Delete(It.IsAny<Domain.Artist>()), Times.Once);
        }
    }
}