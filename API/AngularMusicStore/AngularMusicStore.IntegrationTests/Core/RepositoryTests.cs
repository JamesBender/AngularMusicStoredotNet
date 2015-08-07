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
        public void ShouldBeAbleToSearchForAnAristByName()
        {
            var nameToSearchFor = "ABC";

            var listOfGoodNames = new List<string> {"ABCDE", "DABCE", "DEABC"};
            var badName = "FGHIJ";

            var listOfArtistsToFind = listOfGoodNames.Select(goodName => new Artist {Name = goodName}).ToList();
            var badArtist = new Artist {Name = badName};

            var listOfArtistsToFindId = listOfArtistsToFind.Select(foundArtist => _repository.Save(foundArtist)).ToList();
            var badArtistId = _repository.Save(badArtist);

            listOfArtistsToFindId.ForEach(x => Assert.IsNotNull(x));
            Assert.IsNotNull(badArtistId);

            var listOfFoundArtists = _repository.SearchByName<Artist>(nameToSearchFor);

            Assert.IsNotNull(listOfFoundArtists);
            var ofFoundArtists = listOfFoundArtists as Artist[] ?? listOfFoundArtists.ToArray();
            Assert.AreEqual(listOfArtistsToFind.Count, ofFoundArtists.ToList().Count);
            listOfArtistsToFind.ForEach(x => Assert.IsNotNull(ofFoundArtists.FirstOrDefault(y => y.Name == x.Name)));
            Assert.IsNull(listOfArtistsToFind.FirstOrDefault(x => x.Name == badName));

            foreach (var artist in listOfArtistsToFind)
            {
                _repository.Delete(artist);
            }

            _repository.Delete(badArtist);
        }

        [Test]
        public void ShouldBeAbleToSearchForAnAlbumsByName()
        {
            var nameToSearchFor = "ABC";

            var listOfGoodNames = new List<string> { "ABCDE", "DABCE", "DEABC" };
            var badName = "FGHIJ";

            var listOfAlbumsToFind = listOfGoodNames.Select(goodName => new Album { Name = goodName, ReleaseDate = DateTime.Now}).ToList();
            var badAlbum = new Album { Name = badName, ReleaseDate = DateTime.Now};

            var listOfAlbumsToFindId = listOfAlbumsToFind.Select(foundAlbum => _repository.Save(foundAlbum)).ToList();
            var badAlbumId = _repository.Save(badAlbum);

            listOfAlbumsToFindId.ForEach(x => Assert.IsNotNull(x));
            Assert.IsNotNull(badAlbumId);

            var listOfFoundAlbums = _repository.SearchByName<Album>(nameToSearchFor);

            Assert.IsNotNull(listOfFoundAlbums);
            var ofFoundAlbums = listOfFoundAlbums as Album[] ?? listOfFoundAlbums.ToArray();
            Assert.AreEqual(listOfAlbumsToFind.Count, ofFoundAlbums.ToList().Count);
            listOfAlbumsToFind.ForEach(x => Assert.IsNotNull(ofFoundAlbums.FirstOrDefault(y => y.Name == x.Name)));
            Assert.IsNull(listOfAlbumsToFind.FirstOrDefault(x => x.Name == badName));

            foreach (var album in listOfAlbumsToFind)
            {
                _repository.Delete(album);
            }

            _repository.Delete(badAlbum);
        }

        [Test]
        public void ShouldBeAbleToStoreAnArtistWithACollectionOfAlbumsWhichHaveACollectionOfTracksAndDeletingTheArtistShouldCascadeToAlbumsAndTracks()
        {
            var trackOneA = new Track();
            var trackOneB = new Track();
            var trackTwoA = new Track();
            var trackTwoB = new Track();
            var trackTwoC = new Track();

            var albumOneName = Guid.NewGuid().ToString();
            var albumTwoName = Guid.NewGuid().ToString();

            var albumOne = new Album {ReleaseDate = DateTime.Now, Name = albumOneName};
            var albumTwo = new Album {ReleaseDate = DateTime.Now, Name = albumTwoName};

            albumOne.AddTrack(trackOneA);
            albumOne.AddTrack(trackOneB);
            albumTwo.AddTrack(trackTwoA);
            albumTwo.AddTrack(trackTwoB);
            albumTwo.AddTrack(trackTwoC);

            var albumOneTrackCount = albumOne.Tracks.Count;
            var albumTwoTrackCount = albumTwo.Tracks.Count;

            var artist = new Artist();
            artist.AddAlbum(albumOne);
            artist.AddAlbum(albumTwo);
            var numberOfAlbums = artist.Albums.Count;

            var artistId = _repository.Save(artist);

            Assert.IsNotNull(artistId);

            artist = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(artist);
            Assert.IsNotNull(artist.Albums);
            Assert.AreEqual(numberOfAlbums, artist.Albums.Count(x => x.Parent.Id == artist.Id));

            var albumOneResult = artist.Albums.FirstOrDefault(x => x.Name == albumOneName);
            Assert.IsNotNull(albumOneResult);
            Assert.AreEqual(albumOneTrackCount, albumOneResult.Tracks.Count);

            var albumTwoResult = artist.Albums.FirstOrDefault(x => x.Name == albumTwoName);
            Assert.IsNotNull(albumTwoResult);
            Assert.AreEqual(albumTwoTrackCount, albumTwoResult.Tracks.Count);

            _repository.Delete(artist);
            var listOfAlbums = _repository.GetAll<Album>();

            Assert.IsNotNull(listOfAlbums);
            Assert.AreEqual(0, listOfAlbums.Count());

            var listOfTracks = _repository.GetAll<Track>();

            Assert.IsNotNull(listOfTracks);
            Assert.AreEqual(0, listOfTracks.Count());
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
            var album = new Album {Name = albumName, CoverUri = albumCoverUrl, ReleaseDate = albumReleaseDate};
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
                    x => x.Name == albumName && x.CoverUri == albumCoverUrl));

            
            _repository.Delete(artist);
        }
    }
}