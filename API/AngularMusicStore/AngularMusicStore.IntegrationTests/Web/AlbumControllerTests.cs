using System;
using System.Collections.Generic;
using System.Globalization;
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
            var newAlbumReleaseDate = DateTime.Now;
            var newAlbum = new Album
            {
                Name = newAlbumName,
                CoverUri = newAlbumCoverUri,
                ReleaseDate = newAlbumReleaseDate,
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
            newAlbum =
                artist.Albums.FirstOrDefault(
                    x =>
                        x.Name == newAlbumName && x.CoverUri.IndexOf(newAlbumCoverUri, StringComparison.Ordinal) > 0 &&
                        x.ReleaseDate.ToString(CultureInfo.InvariantCulture) == newAlbumReleaseDate.ToString(CultureInfo.InvariantCulture));
                                                             
                                                          
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

        [Test]
        public void ShouldBeAbleToFindAListOfAlbumsByPartialName()
        {
            var nameFragmentToFind = "ABC";
            var listOfGoodNames = new List<string> { "ABCDE", "DABCE", "DEABC" };
            var listOfBadNames = new List<string> { "LMNOP", "PBJWB", "IHBTD" };
            var artist = new Artist {Name = "artist"};

            var artistSaveResponse = _artistController.PostArtist(artist);
            Assert.IsNotNull(artistSaveResponse);
            Guid artistId;
            Assert.IsTrue(artistSaveResponse.TryGetContentValue(out artistId));
            var artistResponse = _artistController.GetById(artistId.ToString());
            Assert.IsNotNull(artistResponse);
            Assert.IsTrue(artistResponse.TryGetContentValue(out artist));

            var albumsToFind = new List<Guid>();
            var albumsToNotFind = new List<Guid>();

            foreach (var postResponse in listOfGoodNames.Select(goodName => _albumController.PostAlbum(new Album { Name = goodName, ReleaseDate = DateTime.Now, Parent = artist})))
            {
                Guid albumId;
                Assert.IsTrue(postResponse.TryGetContentValue(out albumId));
                albumsToFind.Add(albumId);
            }

            foreach (var postResponse in listOfBadNames.Select(badName => _albumController.PostAlbum(new Album { Name = badName, ReleaseDate = DateTime.Now, Parent = artist})))
            {
                Guid albumId;
                Assert.IsTrue(postResponse.TryGetContentValue(out albumId));
                albumsToNotFind.Add(albumId);
            }

            var listOfAllAlbums = new List<Album>();
            foreach (var albumId in albumsToFind)
            {
                var albumResponse = _albumController.GetAlbum(albumId.ToString());
                Assert.AreEqual(HttpStatusCode.OK, albumResponse.StatusCode);
                Album retrievedAlbum;
                Assert.IsTrue(albumResponse.TryGetContentValue(out retrievedAlbum));
                Assert.IsNotNull(retrievedAlbum);
                listOfAllAlbums.Add(retrievedAlbum);
            }

            foreach (var albumId in albumsToNotFind)
            {
                var albumResponse = _albumController.GetAlbum(albumId.ToString());
                Assert.AreEqual(HttpStatusCode.OK, albumResponse.StatusCode);
                Album retrievedAlbum;
                Assert.IsTrue(albumResponse.TryGetContentValue(out retrievedAlbum));
                Assert.IsNotNull(retrievedAlbum);
                listOfAllAlbums.Add(retrievedAlbum);
            }

            Assert.IsNotNull(listOfAllAlbums);
            Assert.AreEqual(listOfAllAlbums.Count(), albumsToFind.Count() + albumsToNotFind.Count());
            listOfGoodNames.ForEach(x => Assert.IsNotNull(listOfAllAlbums.FirstOrDefault(a => a.Name == x)));
            listOfBadNames.ForEach(x => Assert.IsNotNull(listOfAllAlbums.FirstOrDefault(a => a.Name == x)));

            var findAlbumResults = _albumController.GetAlbums(nameFragmentToFind);

            Assert.IsNotNull(findAlbumResults);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.AreEqual(listOfGoodNames.Count(), findAlbumResults.Count());
            listOfGoodNames.ForEach(x => Assert.IsNotNull(findAlbumResults.FirstOrDefault(a => a.Name == x)));
            listOfBadNames.ForEach(x => Assert.IsNull(findAlbumResults.FirstOrDefault(a => a.Name == x)));

//            albumsToFind.ForEach(x => _albumController.Delete(x.ToString()));
//            albumsToNotFind.ForEach(x => _albumController.Delete(x.ToString()));
//
//            listOfAllAlbums = _artistController.GetArtists();
//
//            Assert.IsNotNull(listOfAllAlbums);
//            Assert.AreEqual(listOfAllAlbums.Count(), 0);
        }
    }
}