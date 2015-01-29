using System;
using System.Linq;
using AngularMusicStore.Api;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Factories;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests.Web
{
    [TestFixture]
    public class ArtistModelTests
    {
        private IArtistModel _artistModel;

        [SetUp]
        public void SetupTests()
        {
            AutomapperConfiguration.Configure();
            var kernel = new StandardKernel(new DomainModule(), new ApiModule());
            _artistModel = kernel.Get<IArtistModel>();
        }

        [Test]
        public void ShouldBeAbleToCreateThenRetreiveThenUpdateThenDeleteAnArtistWithTheArtistModel()
        {
            var artistName = Guid.NewGuid().ToString();
            var artist = new Artist {Name = artistName};
            var albumName = Guid.NewGuid().ToString();
            var album = new Album {ReleaseDate = DateTime.Now, Name = albumName};
            artist.AddAlbum(album);

            var artistId = _artistModel.Save(artist);

            Assert.IsNotNull(artistId);
            
            //Retrieve
            artist = _artistModel.GetById(artistId);

            Assert.IsNotNull(artist);
            Assert.AreEqual(artistName, artist.Name);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(1, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == albumName));

            //Update
            var newArtistName = Guid.NewGuid().ToString();
            var newAlbumName = Guid.NewGuid().ToString();
            artist.Name = newArtistName;
            var newAlbum = new Album {Name = newAlbumName, ReleaseDate = DateTime.Now};
            artist.AddAlbum(newAlbum);

            var newArtistId = _artistModel.Save(artist);
            
            Assert.IsNotNull(newArtistId);
            Assert.AreEqual(artistId, newArtistId);

            artist = _artistModel.GetById(artistId);

            Assert.IsNotNull(artist);
            Assert.AreEqual(newArtistName, artist.Name);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(2, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == albumName));
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == newAlbumName));

            //Delete
            _artistModel.Delete(artist.Id);

            var listOfArtists = _artistModel.GetArtists();

            Assert.IsNotNull(listOfArtists);
            Assert.IsNull(listOfArtists.FirstOrDefault(x => x.Id == artistId));
        }
    }
}