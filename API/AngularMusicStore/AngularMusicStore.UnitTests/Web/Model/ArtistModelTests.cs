using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Core.Persistence;
using AngularMusicStore.Core.Services;
using Moq;
using NUnit.Framework;
using Domain = AngularMusicStore.Core.Entities;
using ApiModel = AngularMusicStore.Api.Models.ViewModels;

namespace AngularMusicStore.UnitTests.Web.Model
{
    [TestFixture]
    public class ArtistModelTests
    {
        private Mock<IArtistService> _artistService;
        private ArtistModel _artistModel;

        [SetUp]
        public void SetupTests()
        {
            ApiModel.AutomapperConfiguration.Configure();
            _artistService = new Mock<IArtistService>();
            _artistModel = new ArtistModel(_artistService.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfArtistsFromTheArtistModel()
        {
            var listOfDomainArtists = new List<Domain.Artist> {new Domain.Artist(), new Domain.Artist()};
            _artistService.Setup(x => x.GetAll()).Returns(listOfDomainArtists);
            
            var result = _artistModel.GetArtists();

            Assert.IsNotNull(result);
            Assert.AreEqual(listOfDomainArtists.Count, result.Count());
        }

        [Test]
        public void ShouldBeAbleToGetASpecificArtistFromTheArtistModel()
        {
            var artistId = Guid.NewGuid();
            _artistService.Setup(x => x.GetById(artistId)).Returns(new Domain.Artist());

            var result = _artistModel.GetById(artistId);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToSaveANewArtist()
        {
            var artist = new ApiModel.Artist();
            var album = new ApiModel.Album();
            artist.AddAlbum(album);

            var result = _artistModel.Save(artist);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToSaveAnExistingArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new ApiModel.Artist {Id = artistId};
            _artistService.Setup(x => x.Save(It.IsAny<Domain.Artist>())).Returns(artistId);

            var result = _artistModel.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnExistingArtist()
        {
            var artist = new ApiModel.Artist {Id = Guid.NewGuid()};

            _artistModel.Delete(artist.Id);

            _artistService.Verify(x => x.Delete(artist.Id), Times.Once);
        }
    }
}