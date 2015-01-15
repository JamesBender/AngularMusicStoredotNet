using System;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Factories;
using AngularMusicStore.Core.Services;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests.Core
{
    public class ArtistServiceTests
    {
        private IArtistService _artistService;

        [SetUp]
        public void SetupTests()
        {
            var kernel = new StandardKernel(new DomainModule());
            _artistService = kernel.Get<IArtistService>();
            Assert.IsNotNull(_artistService);
        }

        [Test]
        public void ShouldBeAbleToSaveThenRetriveThenUpdateThenDeleteAnArtist()
        {
            //Save
            var artistName = Guid.NewGuid().ToString();
            var artist = new Artist {Name = artistName};

            var artistId = _artistService.Save(artist);

            Assert.IsNotNull(artistId);

            //Retrive
            artist = _artistService.GetById(artistId);

            Assert.IsNotNull(artist);
            Assert.AreEqual(artistName, artist.Name);

            //Update
            artistName = Guid.NewGuid().ToString();
            artist.Name = artistName;

            _artistService.Save(artist);
            artist = _artistService.GetById(artistId);

            Assert.IsNotNull(artist);
            Assert.AreEqual(artistName, artist.Name);

            //Delete
            _artistService.Delete(artist);

            artist = _artistService.GetById(artistId);

            Assert.IsNull(artist);
        }
    }
}