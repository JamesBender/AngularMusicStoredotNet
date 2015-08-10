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
        private IAlbumModel _albumModel;
        private Mock<IAlbumService> _albumService;

        [SetUp]
        public void SetupTests()
        {
            AutomapperConfiguration.Configure();
            _albumService = new Mock<IAlbumService>();
            _albumModel = new AlbumModel(_albumService.Object);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAlbumsByAlbumNameFromModel()
        {
            const string nameToFind = "Bob";
            _albumService.Setup(x => x.FindByName(nameToFind))
                .Returns(new List<Domain.Album> { new Domain.Album { Name = nameToFind } });

            var result = _albumModel.GetByPartialName(nameToFind);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldBeAbleToGetAnAlbumByAlbumId()
        {
            //Arrainge
            var domainAlbum = new Domain.Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUri = Guid.NewGuid().ToString()
            };
            var albumId = Guid.NewGuid();
            _albumService.Setup(x => x.GetAlbum(albumId)).Returns(domainAlbum);
           
            //Act
            var result = _albumModel.GetAlbum(albumId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(domainAlbum.Name, result.Name);
            Assert.AreEqual("imagePath/Album/" + domainAlbum.CoverUri, result.CoverUri);
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

        [Test]
        public void ShouldBeAbleToGetTheFirstFiftyAlbumsWhenNoCriteriaProvided()
        {
            const int expectedNumberOfAlbums = 50;
            var listOfAlbumsFromAlbumService = new List<Domain.Album>();
            var listOfAlbumIdsFromAlbumService = new List<Guid>();

            for (var idx = 0; idx < expectedNumberOfAlbums; idx++)
            {
                var newAlbum = new Domain.Album {Id = Guid.NewGuid()};
                listOfAlbumsFromAlbumService.Add(newAlbum);
                listOfAlbumIdsFromAlbumService.Add(newAlbum.Id);
            }

            _albumService.Setup(x => x.GetAlbums()).Returns(listOfAlbumsFromAlbumService);

            var result = _albumModel.GetAlbums();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfAlbums, result.Count());
            foreach (var albumId in listOfAlbumIdsFromAlbumService)
            {
                Assert.IsNotNull(result.FirstOrDefault(x => x.Id == albumId));
            }
        }
    }
}