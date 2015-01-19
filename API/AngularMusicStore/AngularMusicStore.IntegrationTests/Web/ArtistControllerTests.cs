using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMusicStore.Api;
using AngularMusicStore.Api.Controllers;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Factories;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests.Web
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private ArtistController _artistController;

        [SetUp]
        public void SetupTests()
        {
            AutomapperConfiguration.Configure();
            var kernel = new StandardKernel(new DomainModule(), new ApiModule());
            _artistController = kernel.Get<ArtistController>();
            _artistController.Request = new HttpRequestMessage();
            _artistController.Configuration = new HttpConfiguration();
        }

        [Test]
        public void ShouldBeAbleToCreateRetrieveUpdateAndDeleteAnArtistWithTheController()
        {
            var albumName = Guid.NewGuid().ToString();
            var coverUrl = Guid.NewGuid().ToString();
            var album = new Album {Name = albumName, ReleaseDate = DateTime.Now, CoverUrl = coverUrl};
            var artistName = Guid.NewGuid().ToString();
            var artist = new Artist {Name = artistName};
            artist.AddAlbum(album);

            var artistId = _artistController.PostArtist(artist);

            Assert.IsNotNull(artistId);
            
            //Retrieve
            var response = _artistController.GetById(artistId.ToString());

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.TryGetContentValue(out artist));
            Assert.IsNotNull(artist);
            Assert.AreEqual(artistName, artist.Name);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(1, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == albumName));

            //Update
            var newArtistName = Guid.NewGuid().ToString();
            artist.Name = newArtistName;
            var newAlbumName = Guid.NewGuid().ToString();
            var newAlbumCoverUrl = Guid.NewGuid().ToString();
            var newAlbum = new Album {Name = newAlbumName, ReleaseDate = DateTime.Now, CoverUrl = newAlbumCoverUrl};
            artist.AddAlbum(newAlbum);

            response = _artistController.PutArtist(artist.Id.ToString(), artist);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            response = _artistController.GetById(artistId.ToString());

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.TryGetContentValue(out artist));
            Assert.IsNotNull(artist);
            Assert.AreEqual(newArtistName, artist.Name);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(2, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.First(x => x.Name == albumName));
            Assert.IsNotNull(artist.Albums.First(x => x.Name == newAlbumName));

            //Delete
            response = _artistController.Delete(artist);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var listOfArtists = _artistController.GetArtists();

            Assert.IsNotNull(listOfArtists);
            Assert.IsNull(listOfArtists.FirstOrDefault(x => x.Name == newArtistName));
        }
    }
}