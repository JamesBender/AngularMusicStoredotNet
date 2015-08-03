using System;
using System.Collections.Generic;
using AngularMusicStore.Api;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Factories;
using AngularMusicStore.Core.Services;
using Ninject;
using NUnit.Framework;

namespace AngularMusicStore.IntegrationTests
{
    [TestFixture]
    public class Setup
    {
        [Test]
        public void PrimeDatabaseWithOneArtistWithOneAlbum()
        {
            var kernel = new StandardKernel(new DomainModule());
            var artistService = kernel.Get<IArtistService>();

            var albumArtistInfo = new string [25,6];

            albumArtistInfo[0, 0] = "Clockwork Angles";
            albumArtistInfo[0, 1] = "8/3/2015";
            albumArtistInfo[0, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[0, 3] = "Rush";
            albumArtistInfo[0, 4] = "They are from Canada. They are alright I guess";
            albumArtistInfo[0, 5] = "band.jpg";

            albums.Add(new Album {Name = "Clockwork Angles", ReleaseDate = DateTime.Now.AddYears(-2), CoverUri = "LobsterKnifeFight.jpg"});
            artists.Add(new Artist {Name = "Rush", Bio = "They are from Canada. They are alright I guess", PictureUrl = "band.jpg"});


            artist.AddAlbum(album);
            var result = artistService.Save(artist);
            artist = artistService.GetById(result);
            Assert.IsNotNull(artist);
        }
    }
}