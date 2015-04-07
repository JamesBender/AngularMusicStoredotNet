using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMusicStore.Api.Controllers;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Exceptions;
using Moq;
using NUnit.Framework;

namespace AngularMusicStore.UnitTests.Web.Controller
{
    [TestFixture]
    public class AlbumControllerTests
    {
        private Mock<IAlbumModel> _albumModel;
        private AlbumController _albumController;

        [SetUp]
        public void SetupTests()
        {
            _albumModel = new Mock<IAlbumModel>();
            _albumController = new AlbumController(_albumModel.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Test]
        public void ShouldBeAbleToGetDetailsForAnAlbumByIdWhenAlbumExists()
        {
            var albumId = Guid.NewGuid();
            var album = new Album();

            _albumModel.Setup(x => x.GetAlbum(albumId)).Returns(album);

            var result = _albumController.GetAlbum(albumId.ToString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TryGetContentValue(out album));
            Assert.IsNotNull(album);
            _albumModel.Verify(x => x.GetAlbum(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void ShouldGetBackAnHttp404WhenTheAlbumDoesNotExist()
        {
            var result = _albumController.GetAlbum(Guid.NewGuid().ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void ShouldGetBackAnHttp400WhenTheAlbumDoesNotExist()
        {
            var result = _albumController.GetAlbum("this is not a guid");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            _albumModel.Verify(x => x.GetAlbum(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public void ShouldBeAbleToSaveAnAlbumWithAValidArtist()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist {Id = artistId};
            var album = new Album {Parent = artist};
            var albumId = Guid.NewGuid();
            _albumModel.Setup(x => x.Save(artistId, album)).Returns(albumId);

            var result = _albumController.PostAlbum(album);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Guid returnAlbumId;
            Assert.IsTrue(result.TryGetContentValue(out returnAlbumId));
            Assert.AreEqual(albumId, returnAlbumId);
        }

        public void ShouldGetAnHttp400WhenTryingToSaveAnAlbumWithABadParentId()
        {
            var album = new Album {Parent = new Artist()};

            var result = _albumController.PostAlbum(album);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnAlbum()
        {
            var albumId = Guid.NewGuid();

            var result = _albumController.DeleteAlbum(albumId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void ShouldGetBackAnHttp404StatusWhenAlbumToBeDeleteDoesNotExist()
        {
            var albumId = Guid.NewGuid();
            _albumModel.Setup(x => x.Delete(albumId)).Throws(new DataNotFoundException(""));

            var result = _albumController.DeleteAlbum(albumId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void ShouldGetBackAnHttp400StatusWhenDeletingAnAlbumWithABadGuid()
        {
            var result = _albumController.DeleteAlbum("this is not a guid");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void ShouldBeAbleToGetListOfAlbumsByName()
        {
            const string albumName = "Bob";
            _albumModel.Setup(x => x.GetByPartialName(albumName))
                .Returns(new List<Album> {new Album {Name = albumName}});

            var result = _albumController.GetAlbums(albumName);
            
            Assert.IsNotNull(result);
        }
    }
}