using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularMusicStore.Api;
using AngularMusicStore.Api.Controllers;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Factories;
using AngularMusicStore.IntegrationTests.Core;
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
            var album = new Album {Name = albumName, ReleaseDate = DateTime.Now, CoverUri = coverUrl};
            var artistName = Guid.NewGuid().ToString();
            var artist = new Artist {Name = artistName};
            artist.AddAlbum(album);

            var response = _artistController.PostArtist(artist);

            Assert.IsNotNull(response);
            Guid artistId;
            Assert.IsTrue(response.TryGetContentValue(out artistId));
            
            //Retrieve
            response = _artistController.GetById(artistId.ToString());

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
            var newAlbum = new Album {Name = newAlbumName, ReleaseDate = DateTime.Now, CoverUri = newAlbumCoverUrl};
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
            response = _artistController.Delete(artist.Id.ToString());

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var listOfArtists = _artistController.GetArtists();

            Assert.IsNotNull(listOfArtists);
            Assert.IsNull(listOfArtists.FirstOrDefault(x => x.Name == newArtistName));
        }

        [Test]
        public void ShouldBeAbleToFindAListOfArtistsByPartialName()
        {
            var nameFragmentToFind = "ABC";
            var listOfGoodNames = new List<string> {"ABCDE", "DABCE", "DEABC"};
            var listOfBadNames = new List<string> {"LMNOP", "PBJWB", "IHBTD"};

            var artistsToFind = new List<Guid>();
            var artistsToNotFind = new List<Guid>();

            foreach (var postResponse in listOfGoodNames.Select(goodName => _artistController.PostArtist(new Artist {Name = goodName})))
            {
                Guid artistId;
                Assert.IsTrue(postResponse.TryGetContentValue(out artistId));
                artistsToFind.Add(artistId);
            }

            foreach (var postResponse in listOfBadNames.Select(badName => _artistController.PostArtist(new Artist { Name = badName })))
            {
                Guid artistId;
                Assert.IsTrue(postResponse.TryGetContentValue(out artistId));
                artistsToNotFind.Add(artistId);
            }

            var listOfAllArtists = _artistController.GetArtists();

            Assert.IsNotNull(listOfAllArtists);
            Assert.AreEqual(listOfAllArtists.Count(), artistsToFind.Count() + artistsToNotFind.Count());
            listOfGoodNames.ForEach(x => Assert.IsNotNull(listOfAllArtists.FirstOrDefault(a => a.Name == x)));
            listOfBadNames.ForEach(x => Assert.IsNotNull(listOfAllArtists.FirstOrDefault(a => a.Name == x)));

            var findArtistResults = _artistController.GetArtists(nameFragmentToFind);
            
            Assert.IsNotNull(findArtistResults);
            Assert.AreEqual(listOfGoodNames.Count(), findArtistResults.Count());
            listOfGoodNames.ForEach(x => Assert.IsNotNull(findArtistResults.FirstOrDefault(a => a.Name == x)));
            listOfBadNames.ForEach(x => Assert.IsNull(findArtistResults.FirstOrDefault(a => a.Name == x)));

            artistsToFind.ForEach(x => _artistController.Delete(x.ToString()));
            artistsToNotFind.ForEach(x => _artistController.Delete(x.ToString()));
            
            listOfAllArtists = _artistController.GetArtists();

            Assert.IsNotNull(listOfAllArtists);
            Assert.AreEqual(listOfAllArtists.Count(), 0);
        }
    }
}