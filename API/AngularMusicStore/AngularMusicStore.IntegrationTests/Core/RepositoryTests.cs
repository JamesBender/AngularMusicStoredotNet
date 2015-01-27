using System;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Factories;
using AngularMusicStore.Core.Persistence;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests.Core
{
    [TestFixture]
    public class RepositoryTests
    {
        private IRepository _repository;
        
        [SetUp]
        public void SetupTests()
        {
            var kernel = new StandardKernel(new DomainModule());
            _repository = kernel.Get<IRepository>();
        }

        [Test]
        public void ShouldBeAbleToSaveThenRetrieveThenEditThenDeleteAnEntity()
        {
            //Create
            var artist = new Artist();

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Id);

            var artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);

            //Retrieve
            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);

            //Update
            var artistName = Guid.NewGuid().ToString();
            artist.Name = artistName;

            artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);

            //Verify Update
            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);
            Assert.AreEqual(artistName, artist.Name);

            //Delete
            _repository.Delete(artist);

            var result = _repository.GetById<Artist>(artistId);

            Assert.IsNull(result);
        }

        [Test]
        public void ShouldBeAbleToStoreAnArtistWithACollectionOfAlbumsAndDeletingTheArtistShouldCascadeToAlbums()
        {
            var albumOne = new Album {ReleaseDate = DateTime.Now};
            var albumTwo = new Album {ReleaseDate = DateTime.Now};
            var artist = new Artist();
            artist.AddAlbum(albumOne);
            artist.AddAlbum(albumTwo);
            var numberOfAlbums = artist.Albums.Count;

            var artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);

            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Albums);
            //Assert.AreEqual(numberOfAlbums, artist.Albums.Count(x => x.Parent.Id == artist.Id));
            
            _repository.Delete(artist);
            var listOfAlbums = _repository.GetAll<Album>();

            Assert.IsNotNull(listOfAlbums);
            Assert.AreEqual(0, listOfAlbums.Count());
        }

        [Test]
        public void ShouldBeAbleToSaveANewAlbumDirectlyWithoutSavingTheArtistAsLongAsItHasAParent()
        {
            var artist = new Artist {Name = Guid.NewGuid().ToString()};

            var artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);
            Assert.AreEqual(artistId, artist.Id);

            var albumName = Guid.NewGuid().ToString();
            var albumCoverUrl = Guid.NewGuid().ToString();
            var albumReleaseDate = DateTime.Now;
            var album = new Album {Name = albumName, CoverUrl = albumCoverUrl, ReleaseDate = albumReleaseDate};
            artist.AddAlbum(album);
            Assert.IsNotNull(album.Parent);

            var albumId = _repository.Save(album);

            Assert.IsNotNull(albumId);
            Assert.AreEqual(albumId, album.Id);

            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Albums);
            Assert.AreNotEqual(0, artist.Albums.Count);
            Assert.IsNotNull(
                artist.Albums.FirstOrDefault(
                    x => x.Name == albumName && x.CoverUrl == albumCoverUrl));

            
            _repository.Delete(artist);
        }
    }
}