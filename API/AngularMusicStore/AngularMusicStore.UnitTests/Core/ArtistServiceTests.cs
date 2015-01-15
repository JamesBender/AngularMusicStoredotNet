using System;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;
using AngularMusicStore.Core.Services;
using Moq;
using NUnit.Framework;

namespace AngularMusicStore.UnitTests.Core
{
    [TestFixture]
    public class ArtistServiceTests
    {
        [Test]
        public void ShouldBeAbleToGetAnArtistFromTheArtistService()
        {
            var artistId = Guid.NewGuid();
            var artistRepository = new Mock<IRepository>();
            var artistService = new ArtistService(artistRepository.Object);

            var result = artistService.GetById(artistId);
        }
    }
}