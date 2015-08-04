using System.Configuration;
using AngularMusicStore.Api.Models.ViewModels;
using AutoMapper;
using NUnit.Framework;
using Domain = AngularMusicStore.Core.Entities;

namespace AngularMusicStore.UnitTests.Web.Model
{
    [TestFixture]
    public class AutomapperConfigurationTests
    {
        [Test]
        public void ArtistImageUrlShouldHaveBaseUrlPutOnFront()
        {
            AutomapperConfiguration.Configure();

            const string imageName = "imageName";
            var basePath = ConfigurationManager.AppSettings["ImageBasePath"];

            var domainArtist = new Domain.Artist {PictureUrl = imageName};
            
            var result = Mapper.Map<Domain.Artist, Artist>(domainArtist);

            Assert.IsNotNull(result);
            Assert.AreEqual($"{basePath}Artist/{imageName}", result.PictureUrl);
        }

        [Test]
        public void AlbumCoverImageUrlShouldHaveBaseUrlPutOnFront()
        {
            AutomapperConfiguration.Configure();

            const string imageName = "imageName";
            var basePath = ConfigurationManager.AppSettings["ImageBasePath"];

            var domainAlbum = new Domain.Album { CoverUri = imageName };

            var result = Mapper.Map<Domain.Album, Album>(domainAlbum);

            Assert.IsNotNull(result);
            Assert.AreEqual($"{basePath}Album/{imageName}", result.CoverUri);
        }
    }
}