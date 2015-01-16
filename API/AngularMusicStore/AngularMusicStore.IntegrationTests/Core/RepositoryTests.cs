using System;
using System.Collections.Generic;
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
            artist.Albums.Add(albumOne);
            artist.Albums.Add(albumTwo);
            var numberOfAlbums = artist.Albums.Count;

            var artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);

            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(numberOfAlbums, artist.Albums.Count);

            _repository.Delete(artist);
            var listOfAlbums = _repository.GetAll<Album>();

            Assert.IsNotNull(listOfAlbums);
            Assert.AreEqual(0, listOfAlbums.Count());
        }        
    }
}