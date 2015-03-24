//using System;
//using AngularMusicStore.Api;
//using AngularMusicStore.Core.Entities;
//using AngularMusicStore.Core.Factories;
//using AngularMusicStore.Core.Services;
//using Ninject;
//using NUnit.Framework;
//
//namespace AngularMusicStore.IntegrationTests
//{
//    [TestFixture]
//    public class Setup
//    {
//        [Test]
//        public void PrimeDatabaseWithOneArtistWithOneAlbum()
//        {
//            var kernel = new StandardKernel(new DomainModule());
//            var artistService = kernel.Get<IArtistService>();
//
//            var album = new Album {Name = "Clockwork Angles", ReleaseDate = DateTime.Now.AddYears(-2)};
//            var artist = new Artist {Name = "Rush"};
//            artist.AddAlbum(album);
//            var result = artistService.Save(artist);
//            artist = artistService.GetById(result);
//            Assert.IsNotNull(artist);
//        }
//    }
//}