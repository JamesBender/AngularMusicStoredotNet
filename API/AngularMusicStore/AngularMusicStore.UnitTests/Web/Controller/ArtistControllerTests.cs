using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMusicStore.Api.Controllers;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using Moq;
using NUnit.Framework;

namespace AngularMusicStore.UnitTests.Web.Controller
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private ArtistController _artistController;
        private Mock<IArtistModel> _artistModel;

        [SetUp]
        public void SetupTests()
        {
            _artistModel = new Mock<IArtistModel>();
            _artistController = new ArtistController(_artistModel.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAllArtists()
        {
            var listOfArtists = new List<Artist> {new Artist(), new Artist(), new Artist()};
            var numberOfArtists = listOfArtists.Count;
            _artistModel.Setup(x => x.GetArtists()).Returns(listOfArtists);

            var result = _artistController.GetArtists();

            Assert.IsNotNull(result);
            Assert.AreEqual(numberOfArtists, result.Count());
            _artistModel.Verify(x => x.GetArtists(), Times.Once);
        }

        [Test]
        public void ShouldBeAbleToGetASpecificArtistByIdWhenIdIsValidGuidAndArtistExists()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist {Id = artistId};
            _artistModel.Setup(x => x.GetById(artistId)).Returns(artist);

            var result = _artistController.GetById(artistId.ToString());
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.TryGetContentValue(out artist));
            Assert.IsNotNull(artist);
            Assert.AreEqual(artistId, artist.Id);
        }

        [Test]
        public void ShouldGetBackAnHttp400ErrorForMalformedArtistId()
        {
            var result = _artistController.GetById("this is not a guid");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            _artistModel.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public void ShouldGetBackAnHttp404ErrorForNoAristFound()
        {
            var result = _artistController.GetById(Guid.NewGuid().ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void ShouldBeAbleToPostANewArtist()
        {
            var artist = new Artist();

            var result = _artistController.PostArtist(artist);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToPutAnNewArtist()
        {
            var artist = new Artist();

            var result = _artistController.PutArtist(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [Test]
        public void ShouldBeAbleToPutAnExistingArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist {Id = artistId};

            var result = _artistController.PutArtist(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnExistingArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist {Id = artistId};
            _artistModel.Setup(x => x.GetById(artistId)).Returns(artist);

            var result = _artistController.Delete(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void ShouldGetBackAnHttp404StatusWhenArtistToBeDeleteDoesNotExist()
        {
            var result = _artistController.Delete(new Artist());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}