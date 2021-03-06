﻿using System;
using AngularMusicStore.Api.Models.ViewModels;
using AutoMapper;
using FluentNHibernate.Utils;
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
                CoverUri = Guid.NewGuid().ToString()
            };
            domainArtist.AddAlbum(domainAlbum);
            Assert.AreEqual(domainAlbum.Parent.Id, domainArtist.Id);

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
            Assert.AreEqual($"imagePath/Album/{domainAlbum.CoverUri}", apiAlbum.CoverUri);
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
                CoverUri = Guid.NewGuid().ToString()
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
            Assert.AreEqual(apiAlbum.CoverUri, domainAlbum.CoverUri);
        }

        [Test]
        public void ShouldBeAbleToMapDomainAlbumToApiAlbum()
        {
            var domainTrack = new Domain.Track
            {
                AlbumOrder = 1,
                Id = Guid.NewGuid(),
                Length = new TimeSpan(0, 4, 22),
                Name = Guid.NewGuid().ToString(),
                Rating = 3
            };

            var domainAlbum = new Domain.Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now.AddDays(-10),
                CoverUri = Guid.NewGuid().ToString()
            };

            domainAlbum.AddTrack(domainTrack);

            var apiAlbum = Mapper.Map<Domain.Album, Album>(domainAlbum);

            Assert.IsNotNull(apiAlbum);
            Assert.AreEqual(domainAlbum.Id, apiAlbum.Id);
            Assert.AreEqual(domainAlbum.Name, apiAlbum.Name);
            Assert.AreEqual(domainAlbum.ReleaseDate, apiAlbum.ReleaseDate);
            Assert.AreEqual($"imagePath/Album/{domainAlbum.CoverUri}", apiAlbum.CoverUri);

            Assert.IsNotNull(apiAlbum.Tracks);
            Assert.AreEqual(1, apiAlbum.Tracks.Count);

            var apiTrack = apiAlbum.Tracks[0];

            Assert.IsNotNull(apiTrack);
            Assert.AreEqual(domainTrack.AlbumOrder, apiTrack.AlbumOrder);
            Assert.AreEqual(domainTrack.Id, apiTrack.Id);
            Assert.AreEqual(domainTrack.Length, apiTrack.Length);
            Assert.AreEqual(domainTrack.Name, apiTrack.Name);
            Assert.AreEqual(domainTrack.Rating, apiTrack.Rating);
        }

        [Test]
        public void ShouldBeAbleToMapApiAlbumToDomainAlbum()
        {
            var apiTrack = new Track
            {
                AlbumOrder = 1,
                Id = Guid.NewGuid(),
                Length = new TimeSpan(0, 6, 4),
                Name = Guid.NewGuid().ToString(),
                Rating = 4
            };
            var apiAlbum = new Album
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                ReleaseDate = DateTime.Now.AddDays(-10),
                CoverUri = Guid.NewGuid().ToString()
            };
            apiAlbum.AddTrack(apiTrack);
            var domainAlbum = Mapper.Map<Album, Domain.Album>(apiAlbum);

            Assert.IsNotNull(domainAlbum);
            Assert.AreEqual(apiAlbum.Id, domainAlbum.Id);
            Assert.AreEqual(apiAlbum.Name, domainAlbum.Name);
            Assert.AreEqual(apiAlbum.ReleaseDate, domainAlbum.ReleaseDate);
            Assert.AreEqual(apiAlbum.CoverUri, domainAlbum.CoverUri);
            Assert.IsNotNull(domainAlbum.Tracks);
            Assert.AreEqual(1, domainAlbum.Tracks.Count);

            var domainTrack = domainAlbum.Tracks[0];
            Assert.IsNotNull(domainTrack);

            Assert.AreEqual(apiTrack.AlbumOrder, domainTrack.AlbumOrder);
            Assert.AreEqual(apiTrack.Id, domainTrack.Id);
            Assert.AreEqual(apiTrack.Length, domainTrack.Length);
            Assert.AreEqual(apiTrack.Name, domainTrack.Name);
            Assert.AreEqual(apiTrack.Rating, domainTrack.Rating);
        }
    }
}