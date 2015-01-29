using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Services;
using Moq;
using NUnit.Framework;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.UnitTests.Web.Model
{
    [TestFixture]
    public class AlbumModelTests
    {
        private AlbumModel _albumModel;
        private Mock<IAlbumService> _albumService;

        [SetUp]
        public void SetupTests()
        {
            AutomapperConfiguration.Configure();
            _albumService = new Mock<IAlbumService>();
            _albumModel = new AlbumModel(_albumService.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAnAlbumByAlbumId()
        {
            //Arrainge
            var domainAlbum = new Domain.Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUrl = Guid.NewGuid().ToString()
            };
            var albumId = Guid.NewGuid();
            _albumService.Setup(x => x.GetAlbum(albumId)).Returns(domainAlbum);
           
            //Act
            var result = _albumModel.GetAlbum(albumId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(domainAlbum.Name, result.Name);
            Assert.AreEqual(domainAlbum.CoverUrl, result.CoverUrl);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenAskingForAnAlbumThatDoesntExistIShouldGetANullArgumentException()
        {
            //Arraninge
            var badAlbumId = Guid.NewGuid();
            
            //Act
            var result = _albumModel.GetAlbum(badAlbumId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAlbumsByArtistId()
        {
            var artistId = Guid.NewGuid();
            var listOfAlbums = new List<Domain.Album> {new Domain.Album(), new Domain.Album(), new Domain.Album()};
            _albumService.Setup(x => x.GetAlbumsByArtist(artistId)).Returns(listOfAlbums);

            var result = _albumModel.GetAlbumsByArtist(artistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(listOfAlbums.Count, result.Count());
        }

        [Test]
        public void ShouldBeAbleToSaveAnAlbumWithAValidArtist()
        {
            var artistId = Guid.NewGuid();
            var album = new Album();
            var albumId = Guid.NewGuid();
            _albumService.Setup(x => x.Save(artistId, It.IsAny<Domain.Album>())).Returns(albumId);

            var result = _albumModel.Save(artistId, album);

            Assert.IsNotNull(result);
            Assert.AreEqual(albumId, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteASpecificAlbum()
        {
            var album = new Album {Id = Guid.NewGuid()};
            
            _albumModel.Delete(album.Id);

            _albumService.Verify(x => x.Delete(It.IsAny<Guid>()));
        }
    }
}