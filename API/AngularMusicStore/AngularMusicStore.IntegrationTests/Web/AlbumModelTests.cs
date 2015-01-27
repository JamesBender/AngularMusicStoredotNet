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
    public class AlbumModelTests
    {
        private IAlbumModel _albumModel;
        private IArtistModel _artistModel;

        [SetUp]
        public void SetupTests()
        {
            var kernel = new StandardKernel(new DomainModule(), new ApiModule());
            _albumModel = kernel.Get<IAlbumModel>();
            _artistModel = kernel.Get<IArtistModel>();
            AutomapperConfiguration.Configure();
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAlbumsByArtistAndThenGetASpecificAlbumById()
        {
            var albumOne = new Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUrl = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now
            };

            var albumTwo = new Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUrl = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now
            };

            var albumThree = new Album
            {
                Name = Guid.NewGuid().ToString(),
                CoverUrl = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now
            };

            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            artist.AddAlbum(albumOne);
            artist.AddAlbum(albumTwo);
            artist.AddAlbum(albumThree);

            var artistId = _artistModel.Save(artist);

            Assert.IsNotNull(artistId);
            artist.Id = artistId;

            var listOfAlbumsForArtist = _albumModel.GetAlbumsByArtist(artistId).ToList();

            Assert.IsNotNull(listOfAlbumsForArtist);
            Assert.AreEqual(3, listOfAlbumsForArtist.Count());

            var albumToRetreive = listOfAlbumsForArtist.ToList()[0];

            Assert.IsNotNull(albumToRetreive);

            var album = _albumModel.GetAlbum(albumToRetreive.Id);

            Assert.IsNotNull(album);

            Assert.AreEqual(albumToRetreive.Id, album.Id);
            Assert.AreEqual(albumToRetreive.Name, album.Name);
            Assert.AreEqual(albumToRetreive.CoverUrl, album.CoverUrl);
            Assert.AreEqual(albumToRetreive.ReleaseDate, album.ReleaseDate);

            Assert.AreNotEqual(Guid.Empty, artist.Id);
            _artistModel.Delete(artist);

            artist = _artistModel.GetById(artistId);

            Assert.IsNull(artist);
        }

        [Test]
        public void ShouldBeAbleToAddAnAlbumToAnExistingArtist()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};
            artist.AddAlbum(new Album{Name = Guid.NewGuid().ToString(), CoverUrl = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now});
            artist.AddAlbum(new Album{Name = Guid.NewGuid().ToString(), CoverUrl = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now});
            artist.AddAlbum(new Album{Name = Guid.NewGuid().ToString(), CoverUrl = Guid.NewGuid().ToString(), ReleaseDate = DateTime.Now});
            var startingNumberOfAlbums = artist.Albums.Count;

            var artistId = _artistModel.Save(artist);

            Assert.IsNotNull(artistId);
            artist.Id = artistId;

            var newAlbumName = Guid.NewGuid().ToString();
            var newAlbumCoverUrl = Guid.NewGuid().ToString();
            var newAlbum = new Album {Name = newAlbumName, CoverUrl = newAlbumCoverUrl, ReleaseDate = DateTime.Now};

            var newAlbumId = _albumModel.Save(artistId, newAlbum);
            artist = _artistModel.GetById(artistId);

            Assert.IsNotNull(newAlbumId);
            Assert.AreEqual(startingNumberOfAlbums+1, artist.Albums.Count);
            Assert.IsNotNull(artist.Albums.FirstOrDefault(x => x.Name == newAlbumName && x.CoverUrl == newAlbumCoverUrl));

            _artistModel.Delete(artist);

            artist = _artistModel.GetById(artistId);

            Assert.IsNull(artist);
        }
    }
}