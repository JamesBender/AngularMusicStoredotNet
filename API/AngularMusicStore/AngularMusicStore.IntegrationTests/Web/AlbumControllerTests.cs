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
    public class AlbumControllerTests
    {
        private ArtistController _artistController;
        private AlbumController _albumController;

        [SetUp]
        public void SetupTests()
        {
            var kernel = new StandardKernel(new DomainModule(), new ApiModule());
            _artistController = kernel.Get<ArtistController>();
            _albumController = kernel.Get<AlbumController>();
            AutomapperConfiguration.Configure();

            _artistController.Request = new HttpRequestMessage();
            _artistController.Configuration = new HttpConfiguration();

            _albumController.Request = new HttpRequestMessage();
            _albumController.Configuration = new HttpConfiguration();
        }

        [Test]
        public void ShouldBeAbleToSaveAndGetGetASpecificAlbum()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            var existingAlbum = new Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUri = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now
            };
            artist.AddAlbum(existingAlbum);
            var originalNumberOfAlbums = artist.Albums.Count;

            var result = _artistController.PostArtist(artist);

            Assert.IsNotNull(result);
            Guid artistId;
            Assert.IsTrue(result.TryGetContentValue(out artistId));
            
            result = _artistController.GetById(artistId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.TryGetContentValue(out artist));
            Assert.IsNotNull(artist);

            var newAlbumName = Guid.NewGuid().ToString();
            var newAlbumCoverUri = Guid.NewGuid().ToString();
            var newAlbum = new Album
            {
                Name = newAlbumName,
                CoverUri = newAlbumCoverUri,
                ReleaseDate = DateTime.Now,
                Parent = new Artist {Id = artist.Id}
            };

            result = _albumController.PostAlbum(newAlbum);

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Guid albumId;
            Assert.IsTrue(result.TryGetContentValue(out albumId));
            Assert.IsNotNull(albumId);
            Assert.AreNotEqual(Guid.Empty, albumId);

            result = _artistController.GetById(artistId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.TryGetContentValue(out artist));
            Assert.IsNotNull(artist);

            Assert.AreEqual(originalNumberOfAlbums + 1, artist.Albums.Count);
            newAlbum = artist.Albums.FirstOrDefault(x => x.Name == newAlbumName && x.CoverUri == newAlbumCoverUri);
            Assert.IsNotNull(newAlbum);

            result = _albumController.DeleteAlbum(newAlbum.Id.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            result = _artistController.GetById(artistId.ToString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TryGetContentValue(out artist));
            Assert.AreEqual(originalNumberOfAlbums, artist.Albums.Count);
            Assert.IsNull(artist.Albums.FirstOrDefault(x => x.Name == newAlbumName && x.CoverUri == newAlbumCoverUri));

            result = _artistController.Delete(artistId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}