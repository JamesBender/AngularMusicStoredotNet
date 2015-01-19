using System;
using AngularMusicStore.Api.Models.ViewModels;
using AutoMapper;
using NUnit.Framework;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.UnitTests.Web
{
    [TestFixture]
    public class AutomapperTests
    {
        [SetUp]
        public void ConfigureAutomapper()
        {
            AutomapperConfiguration.Configure();
        }

        [Test]
        public void ShouldBeAbleToMapDomainArtistToApiArtist()
        {
            var domainArtist = new Domain.Artist
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            };
            var domainAlbum = new Domain.Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now,
                CoverUrl = Guid.NewGuid().ToString()
            };
            domainArtist.AddAlbum(domainAlbum);
            Assert.AreEqual(domainAlbum.Parent, domainArtist);

            var apiArtist = Mapper.Map<Domain.Artist, Artist>(domainArtist);

            Assert.IsNotNull(apiArtist);
            Assert.AreEqual(domainArtist.Id, apiArtist.Id);
            Assert.AreEqual(domainArtist.Name, apiArtist.Name);
            Assert.IsNotNull(apiArtist.Albums);
            Assert.AreEqual(domainArtist.Albums.Count, apiArtist.Albums.Count);
            Assert.AreEqual(1, apiArtist.Albums.Count);
            var apiAlbum = apiArtist.Albums[0];
            Assert.AreEqual(domainAlbum.Id, apiAlbum.Id);
            Assert.AreEqual(domainAlbum.Name, apiAlbum.Name);
            Assert.AreEqual(domainAlbum.ReleaseDate, apiAlbum.ReleaseDate);
            Assert.AreEqual(domainAlbum.CoverUrl, apiAlbum.CoverUrl);
            Assert.AreEqual(domainAlbum.Parent.Id, apiAlbum.Parent.Id);
        }

        [Test]
        public void ShouldBeAbleToMapApiArtistToDomainArtist()
        {
            var apiArtist = new Artist {Id = Guid.NewGuid(), Name = Guid.NewGuid().ToString()};
            var apiAlbum = new Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now,
                CoverUrl = Guid.NewGuid().ToString()
            };
            apiArtist.Albums.Add(apiAlbum);

            var domainArtist = Mapper.Map<Artist, Domain.Artist>(apiArtist);

            Assert.IsNotNull(domainArtist);
            Assert.AreEqual(apiArtist.Id, domainArtist.Id);
            Assert.AreEqual(apiArtist.Name, domainArtist.Name);
            Assert.IsNotNull(domainArtist.Albums);
            Assert.AreEqual(apiArtist.Albums.Count, domainArtist.Albums.Count);
            Assert.AreEqual(1, domainArtist.Albums.Count);
            var domainAlbum = domainArtist.Albums[0];
            Assert.AreEqual(apiAlbum.Id, domainAlbum.Id);
            Assert.AreEqual(apiAlbum.Name, domainAlbum.Name);
            Assert.AreEqual(apiAlbum.ReleaseDate, domainAlbum.ReleaseDate);
            Assert.AreEqual(apiAlbum.CoverUrl, domainAlbum.CoverUrl);
        }

        [Test]
        public void ShouldBeAbleToMapDomainAlbumToApiAlbum()
        {
            var domainAlbum = new Domain.Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now.AddDays(-10),
                CoverUrl = Guid.NewGuid().ToString()
            };

            var apiAlbum = Mapper.Map<Domain.Album, Album>(domainAlbum);

            Assert.IsNotNull(apiAlbum);
            Assert.AreEqual(domainAlbum.Id, apiAlbum.Id);
            Assert.AreEqual(domainAlbum.Name, apiAlbum.Name);
            Assert.AreEqual(domainAlbum.ReleaseDate, apiAlbum.ReleaseDate);
            Assert.AreEqual(domainAlbum.CoverUrl, apiAlbum.CoverUrl);
        }

        [Test]
        public void ShouldBeAbleToMapApiAlbumToDomainAlbum()
        {
            var apiAlbum = new Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now.AddDays(-10),
                CoverUrl = Guid.NewGuid().ToString()
            };

            var domainAlbum = Mapper.Map<Album, Domain.Album>(apiAlbum);

            Assert.IsNotNull(domainAlbum);
            Assert.AreEqual(apiAlbum.Id, domainAlbum.Id);
            Assert.AreEqual(apiAlbum.Name, domainAlbum.Name);
            Assert.AreEqual(apiAlbum.ReleaseDate, domainAlbum.ReleaseDate);
            Assert.AreEqual(apiAlbum.CoverUrl, domainAlbum.CoverUrl);
        }
    }
}