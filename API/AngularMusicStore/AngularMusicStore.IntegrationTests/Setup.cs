using System;
using System.Collections.Generic;
using System.Linq;
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

            var albumArtistInfo = GetInitialData();
            var trackList = GetTracks();

            var numberOfEntries = albumArtistInfo.GetUpperBound(0);

            for (var idx = 0; idx < numberOfEntries; idx++)
            {
                var albumName = albumArtistInfo[idx, 0];
                var albumDate = albumArtistInfo[idx, 1];
                var albumImage = albumArtistInfo[idx, 2];
                var artistName = albumArtistInfo[idx, 3];
                var artistBio = albumArtistInfo[idx, 4];
                var artistImage = albumArtistInfo[idx, 5];

                var album = new Album {Name = albumName, ReleaseDate = DateTime.Parse(albumDate), CoverUri = albumImage};
                var artist = new Artist {Name = artistName, Bio = artistBio, PictureUrl = artistImage};

                var albumTracks = trackList.FirstOrDefault(x => x.Key == album.Name).Value;

                if (albumTracks != null)
                {
                    foreach (var track in albumTracks)
                    {
                        album.AddTrack(track);
                    }
                }

                artist.AddAlbum(album);
                var result = artistService.Save(artist);
                artist = artistService.GetById(result);
                Assert.IsNotNull(artist);
            }
        }

        private static IDictionary<string, IList<Track>> GetTracks()
        {
            var list = new Dictionary<string, IList<Track>>();

            var imagesAndWordsTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Pull Me Under", Length = new TimeSpan(0, 8, 14)},
                new Track {AlbumOrder = 2, Name = "Another Day", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 3, Name = "Take the Time", Length = new TimeSpan(0, 8, 21)},
                new Track {AlbumOrder = 4, Name = "Surrounded", Length = new TimeSpan(0, 5, 30)},
                new Track {AlbumOrder = 5, Name = "Metropolis Pt. 1", Length = new TimeSpan(0, 9, 32)},
                new Track {AlbumOrder = 6, Name = "Under a Glass Moon", Length = new TimeSpan(0, 7, 3)},
                new Track {AlbumOrder = 7, Name = "Wait For Sleep", Length = new TimeSpan(0, 2, 32)},
                new Track {AlbumOrder = 8, Name = "Learning to Live", Length = new TimeSpan(0, 11, 30)}
            };

            list.Add("Images and Words", imagesAndWordsTracks);

            var clockworkAnglesTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Caravan", Length = new TimeSpan(0, 5, 40)},
                new Track {AlbumOrder = 2, Name = "BU2B", Length = new TimeSpan(0, 5, 10)},
                new Track {AlbumOrder = 3, Name = "Clockwork Angles", Length = new TimeSpan(0, 7, 31)},
                new Track {AlbumOrder = 4, Name = "The Anarchist", Length = new TimeSpan(0, 6, 52)},
                new Track {AlbumOrder = 5, Name = "Carnies", Length = new TimeSpan(0, 4, 52)},
                new Track {AlbumOrder = 6, Name = "Halo Effect", Length = new TimeSpan(0, 3, 14)},
                new Track {AlbumOrder = 7, Name = "Seven Cities of Gold", Length = new TimeSpan(0, 6, 32)},
                new Track {AlbumOrder = 8, Name = "The Wreckers", Length = new TimeSpan(0, 5, 1)},
                new Track {AlbumOrder = 9, Name = "Headlong Flight", Length = new TimeSpan(0, 7, 21)},
                new Track {AlbumOrder = 10, Name = "BU2B2", Length = new TimeSpan(0, 1, 28)},
                new Track {AlbumOrder = 11, Name = "Wish Them Well", Length = new TimeSpan(0, 5, 26)},
                new Track {AlbumOrder = 12, Name = "The Garden", Length = new TimeSpan(0, 6, 59)}
            };

            list.Add("Clockwork Angles", clockworkAnglesTracks);

            var fearOfABlankPlanetTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Fear of a Blank Planet", Length = new TimeSpan(0, 7, 28)},
                new Track {AlbumOrder = 2, Name = "My Ashes", Length = new TimeSpan(0, 5, 7)},
                new Track {AlbumOrder = 3, Name = "Anesthetize", Length = new TimeSpan(0, 17, 42)},
                new Track {AlbumOrder = 4, Name = "Sentimental", Length = new TimeSpan(0, 5, 26)},
                new Track {AlbumOrder = 5, Name = "Way Out of Here", Length = new TimeSpan(0, 7, 37)},
                new Track {AlbumOrder = 6, Name = "Sleep Together", Length = new TimeSpan(0, 7, 28)}
            };

            list.Add("Fear of a Blank Planet", fearOfABlankPlanetTracks);

            var handCannotEraseTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "First Regret / Three Years Older", Length = new TimeSpan(0, 12, 19)},
                new Track {AlbumOrder = 2, Name = "Hand Cannot Erase", Length = new TimeSpan(0, 4, 17)},
                new Track {AlbumOrder = 3, Name = "Perfect Life", Length = new TimeSpan(0, 4, 46)},
                new Track {AlbumOrder = 4, Name = "Routine", Length = new TimeSpan(0, 8, 58)},
                new Track {AlbumOrder = 5, Name = "Home Invastion / Regret #9", Length = new TimeSpan(0, 11, 14)},
                new Track {AlbumOrder = 6, Name = "Tansience", Length = new TimeSpan(0, 2, 43)},
                new Track {AlbumOrder = 7, Name = "Ancestral", Length = new TimeSpan(0, 13, 30)},
                new Track {AlbumOrder = 8, Name = "Happy Returns / Transcendant Here On...", Length = new TimeSpan(0, 7, 54)}
            };

            list.Add("Hand. Cannot. Erase.", handCannotEraseTracks);

            var momentaryLapseOfReasonTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Signs of Life", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 2, Name = "Learning to Fly", Length = new TimeSpan(0, 4, 53)},
                new Track {AlbumOrder = 3, Name = "The Dogs of War", Length = new TimeSpan(0, 6, 5)},
                new Track {AlbumOrder = 4, Name = "One Slip", Length = new TimeSpan(0, 5, 10)},
                new Track {AlbumOrder = 5, Name = "On the Turning Away", Length = new TimeSpan(0, 5, 42)},
                new Track
                {
                    AlbumOrder = 6,
                    Name = "Yet Another Movie / Round and Around",
                    Length = new TimeSpan(0, 7, 28)
                },
                new Track {AlbumOrder = 7, Name = "A New Macine (Part 1)", Length = new TimeSpan(0, 1, 46)},
                new Track {AlbumOrder = 8, Name = "Terminal Frost", Length = new TimeSpan(0, 6, 17)},
                new Track {AlbumOrder = 9, Name = "A New Machine (Part 2)", Length = new TimeSpan(0, 0, 38)},
                new Track {AlbumOrder = 10, Name = "Sorrow", Length = new TimeSpan(0, 8, 46)}
            };

            list.Add("A Momentary Lapse of Reason", momentaryLapseOfReasonTracks);

            var saturdayNightFeverTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Stayin' Alive", Length = new TimeSpan(0, 4, 45)},
                new Track {AlbumOrder = 2, Name = "How Deep Is Your Love", Length = new TimeSpan(0, 4, 5)},
                new Track {AlbumOrder = 3, Name = "Night Fever", Length = new TimeSpan(0, 3, 33)},
                new Track {AlbumOrder = 4, Name = "More Than A Woman", Length = new TimeSpan(0, 3, 18)},
                new Track {AlbumOrder = 5, Name = "If I Can't Have You", Length = new TimeSpan(0, 3, 0)},
                new Track {AlbumOrder = 6, Name = "A Fifth of Beethoven", Length = new TimeSpan(0, 3, 3)},
                new Track {AlbumOrder = 7, Name = "More Than A Woman", Length = new TimeSpan(0, 3, 17)},
                new Track {AlbumOrder = 8, Name = "Manhattan Skyline", Length = new TimeSpan(0, 4, 45)},
                new Track {AlbumOrder = 9, Name = "Calypso Breakdown", Length = new TimeSpan(0, 7, 51)},
                new Track {AlbumOrder = 10, Name = "Night on Disco Mountian", Length = new TimeSpan(0, 5, 13)},
                new Track {AlbumOrder = 11, Name = "Open Sesame", Length = new TimeSpan(0, 4, 1)},
                new Track {AlbumOrder = 12, Name = "Jive Talkin'", Length = new TimeSpan(0, 3, 44)},
                new Track {AlbumOrder = 13, Name = "You Should be Dancing", Length = new TimeSpan(0, 4, 14)},
                new Track {AlbumOrder = 14, Name = "Boogie Shoes", Length = new TimeSpan(0, 2, 17)},
                new Track {AlbumOrder = 15, Name = "Salsnation", Length = new TimeSpan(0, 3, 51)},
                new Track {AlbumOrder = 16, Name = "K-Jee", Length = new TimeSpan(0, 4, 13)},
                new Track {AlbumOrder = 17, Name = "Disco Inferno", Length = new TimeSpan(0, 10, 51)}
            };

            list.Add("Saturday Night Fever Soundtrack", saturdayNightFeverTracks);

            var lifeForRestTracks = new List<Track>{
                new Track {AlbumOrder = 1, Name = "White Flag", Length = new TimeSpan(0, 4, 1)},
                new Track {AlbumOrder = 2, Name = "Stoned", Length = new TimeSpan(0, 5, 55)},
                new Track {AlbumOrder = 3, Name = "Life for Rent", Length = new TimeSpan(0, 3, 41)},
                new Track {AlbumOrder = 4, Name = "Mary's in India", Length = new TimeSpan(0, 3, 41)},
                new Track {AlbumOrder = 5, Name = "See You When You're 40", Length = new TimeSpan(0, 5, 20)},
                new Track {AlbumOrder = 6, Name = "Don't Leave Home", Length = new TimeSpan(0, 3, 46)},
                new Track {AlbumOrder = 7, Name = "Who Makes You Feel", Length = new TimeSpan(0, 4, 20)},
                new Track {AlbumOrder = 8, Name = "Sand in My Shoes", Length = new TimeSpan(0, 4, 59)},
                new Track {AlbumOrder = 9, Name = "Do You Have a Little Time", Length = new TimeSpan(0, 3, 55)},
                new Track {AlbumOrder = 10, Name = "This Land is Mine", Length = new TimeSpan(0, 3, 46)},
                new Track {AlbumOrder = 11, Name = "See the Sun", Length = new TimeSpan(0, 5, 5)},
                new Track {AlbumOrder = 12, Name = "Closer", Length = new TimeSpan(0, 3, 29)}
            };
            list.Add("Life For Rent", lifeForRestTracks);

            var saveRackAndRollTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "The Phoenix", Length = new TimeSpan(0, 4, 4)},
                new Track {AlbumOrder = 2, Name = "My Songs Know What You Did in the Dark (Light 'em Up)", Length = new TimeSpan(0, 3, 9)},
                new Track {AlbumOrder = 3, Name = "Alone Together", Length = new TimeSpan(0, 3, 23)},
                new Track {AlbumOrder = 4, Name = "Where Did the Party Go", Length = new TimeSpan(0, 4, 3)},
                new Track {AlbumOrder = 5, Name = "Just One Yesterday", Length = new TimeSpan(0, 4, 4)},
                new Track {AlbumOrder = 6, Name = "The Mighty Fall", Length = new TimeSpan(0, 3, 32)},
                new Track {AlbumOrder = 7, Name = "Miss Missing You", Length = new TimeSpan(0, 3, 30)},
                new Track {AlbumOrder = 8, Name = "Death Valley", Length = new TimeSpan(0, 3, 46)},
                new Track {AlbumOrder = 9, Name = "Young Volcanos", Length = new TimeSpan(0, 3, 24)},
                new Track {AlbumOrder = 10, Name = "Rat a Tat", Length = new TimeSpan(0, 4, 2)},
                new Track {AlbumOrder = 11, Name = "Save Rock and Rolls", Length = new TimeSpan(0, 4, 41)}
            };

            list.Add("Save Rock and Roll", saveRackAndRollTracks);

            var beyonceTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Pretty Hurts", Length = new TimeSpan(0, 4, 17)},
                new Track {AlbumOrder = 2, Name = "Haunted", Length = new TimeSpan(0, 6, 9)},
                new Track {AlbumOrder = 3, Name = "Drunk in Love", Length = new TimeSpan(0, 5, 23)},
                new Track {AlbumOrder = 4, Name = "Blow", Length = new TimeSpan(0, 5, 9)},
                new Track {AlbumOrder = 5, Name = "No Angel", Length = new TimeSpan(0, 3, 48)},
                new Track {AlbumOrder = 6, Name = "Partition", Length = new TimeSpan(0, 5, 19)},
                new Track {AlbumOrder = 7, Name = "Jealous", Length = new TimeSpan(0, 3, 4)},
                new Track {AlbumOrder = 8, Name = "Rocket", Length = new TimeSpan(0, 6, 31)},
                new Track {AlbumOrder = 9, Name = "Mine", Length = new TimeSpan(0, 6, 18)},
                new Track {AlbumOrder = 10, Name = "XO", Length = new TimeSpan(0, 3, 35)},
                new Track {AlbumOrder = 11, Name = "Flawless", Length = new TimeSpan(0, 4, 10)},
                new Track {AlbumOrder = 12, Name = "Superpower", Length = new TimeSpan(0, 4, 36)},
                new Track {AlbumOrder = 13, Name = "Heaven", Length = new TimeSpan(0, 3, 50)},
                new Track {AlbumOrder = 14, Name = "Blue", Length = new TimeSpan(0, 4, 26)}
            };

            list.Add("Beyonce", beyonceTracks);
           
            var tsTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Welcome to New York", Length = new TimeSpan(0, 3, 32)},
                new Track {AlbumOrder = 2, Name = "Blank Space", Length = new TimeSpan(0, 3, 51)},
                new Track {AlbumOrder = 3, Name = "Style", Length = new TimeSpan(0, 3, 51)},
                new Track {AlbumOrder = 4, Name = "Out of the Woods", Length = new TimeSpan(0, 3, 55)},
                new Track {AlbumOrder = 5, Name = "All You Had to Do Was Stay", Length = new TimeSpan(0, 3, 13)},
                new Track {AlbumOrder = 6, Name = "Shake it Off", Length = new TimeSpan(0, 3, 39)},
                new Track {AlbumOrder = 7, Name = "I Wish You Would", Length = new TimeSpan(0, 3, 27)},
                new Track {AlbumOrder = 8, Name = "Bad Blood", Length = new TimeSpan(0, 3, 31)},
                new Track {AlbumOrder = 9, Name = "Wildest Dreams", Length = new TimeSpan(0, 3, 40)},
                new Track {AlbumOrder = 10, Name = "How You Get the Girl", Length = new TimeSpan(0, 4, 7)},
                new Track {AlbumOrder = 11, Name = "This Love", Length = new TimeSpan(0, 4, 10)},
                new Track {AlbumOrder = 12, Name = "I Know Places", Length = new TimeSpan(0, 3, 15)},
                new Track {AlbumOrder = 13, Name = "Clean", Length = new TimeSpan(0, 4, 30)}
            };

            list.Add("1989", tsTracks);

            var xTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "One", Length = new TimeSpan(0, 4, 12)},
                new Track {AlbumOrder = 2, Name = "I'm A Mess", Length = new TimeSpan(0, 4, 6)},
                new Track {AlbumOrder = 3, Name = "Sing", Length = new TimeSpan(0, 3, 55)},
                new Track {AlbumOrder = 4, Name = "Don't", Length = new TimeSpan(0, 3, 39)},
                new Track {AlbumOrder = 5, Name = "Nina", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 6, Name = "Photograph", Length = new TimeSpan(0, 4, 18)},
                new Track {AlbumOrder = 7, Name = "Bloodstream", Length = new TimeSpan(0, 4, 59)},
                new Track {AlbumOrder = 8, Name = "Tenerife Sea", Length = new TimeSpan(0, 4, 0)},
                new Track {AlbumOrder = 9, Name = "Runaway", Length = new TimeSpan(0, 3, 26)},
                new Track {AlbumOrder = 10, Name = "The Man", Length = new TimeSpan(0, 4, 9)},
                new Track {AlbumOrder = 11, Name = "Thinking Oxut Loud", Length = new TimeSpan(0, 4, 41)},
                new Track {AlbumOrder = 12, Name = "Afire Love", Length = new TimeSpan(0, 5, 14)}
            };

            list.Add("X", xTracks);

            var nightAtTheOperaTracks = new List<Track>{
                new Track {AlbumOrder = 1, Name = "Death on Two Legs", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 2, Name = "Lazing on a Sunday Afternoon", Length = new TimeSpan(0, 1, 8)},
                new Track {AlbumOrder = 3, Name = "I'm in Love with My Car", Length = new TimeSpan(0, 3, 5)},
                new Track {AlbumOrder = 4, Name = "You're My Best Friend", Length = new TimeSpan(0, 2, 40)},
                new Track {AlbumOrder = 5, Name = "39", Length = new TimeSpan(0, 3, 25)},
                new Track {AlbumOrder = 6, Name = "Sweet Lady", Length = new TimeSpan(0, 4, 1)},
                new Track {AlbumOrder = 7, Name = "Seaside Rendezvous", Length = new TimeSpan(0, 2, 13)},
                new Track {AlbumOrder = 8, Name = "The Prophet's Son", Length = new TimeSpan(0, 8, 17)},
                new Track {AlbumOrder = 9, Name = "Love of my Life", Length = new TimeSpan(0, 3, 38)},
                new Track {AlbumOrder = 10, Name = "Good Company", Length = new TimeSpan(0, 3, 26)},
                new Track {AlbumOrder = 11, Name = "Bohemian Rhapsody", Length = new TimeSpan(0, 5, 55)},
                new Track {AlbumOrder = 12, Name = "God Save the Queen", Length = new TimeSpan(0, 1, 11)}
            };

            list.Add("A Night at the Opera", nightAtTheOperaTracks);

            var theRealThingTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "From Out of Nowhere", Length = new TimeSpan(0, 3, 22)},
                new Track {AlbumOrder = 2, Name = "Epic", Length = new TimeSpan(0, 4, 53)},
                new Track {AlbumOrder = 3, Name = "Falling to Pieces", Length = new TimeSpan(0, 5, 15)},
                new Track {AlbumOrder = 4, Name = "Suprise! You're Dead!", Length = new TimeSpan(0, 2, 27)},
                new Track {AlbumOrder = 5, Name = "Zombie Eaters", Length = new TimeSpan(0, 5, 58)},
                new Track {AlbumOrder = 6, Name = "The Real Thing", Length = new TimeSpan(0, 8, 13)},
                new Track {AlbumOrder = 7, Name = "Underwater Love", Length = new TimeSpan(0, 3, 51)},
                new Track {AlbumOrder = 8, Name = "The Morning After", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 9, Name = "Woodpecker from Mars", Length = new TimeSpan(0, 5, 40)},
                new Track {AlbumOrder = 10, Name = "War Pigs", Length = new TimeSpan(0, 7, 45)},
                new Track {AlbumOrder = 11, Name = "Edge of the World", Length = new TimeSpan(0, 4, 10)}                                
            };

            list.Add("The Real Thing", theRealThingTracks);

            var americanIdiotTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "American Idiot", Length = new TimeSpan(0, 2, 54)},
                new Track {AlbumOrder = 2, Name = "Jesus of Suburbia", Length = new TimeSpan(0, 9, 8)},
                new Track {AlbumOrder = 3, Name = "Holiday", Length = new TimeSpan(0, 3, 52)},
                new Track {AlbumOrder = 4, Name = "Boulevard of Broken Dreams", Length = new TimeSpan(0, 4, 20)},
                new Track {AlbumOrder = 5, Name = "Are We the Waiting", Length = new TimeSpan(0, 2, 42)},
                new Track {AlbumOrder = 6, Name = "St. Jimmy", Length = new TimeSpan(0, 2, 56)},
                new Track {AlbumOrder = 7, Name = "Give Me Novacaine", Length = new TimeSpan(0, 3, 25)},
                new Track {AlbumOrder = 8, Name = "She's a Rebel", Length = new TimeSpan(0, 2, 0)},
                new Track {AlbumOrder = 9, Name = "Extraordinary Girl", Length = new TimeSpan(0, 3, 33)},
                new Track {AlbumOrder = 10, Name = "Letterbomb", Length = new TimeSpan(0, 4, 5)},
                new Track {AlbumOrder = 11, Name = "Wake Me Up When September Ends", Length = new TimeSpan(0, 4, 45)},
                new Track {AlbumOrder = 12, Name = "Homecoming", Length = new TimeSpan(0, 9, 18)},
                new Track {AlbumOrder = 13, Name = "Whatsername", Length = new TimeSpan(0, 4, 14)}
            };

            list.Add("American Idiot", americanIdiotTracks);

            var hotFuss = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Jenny Was A Friend of Mine", Length = new TimeSpan(0, 4, 4)},
                new Track {AlbumOrder = 2, Name = "Mr. Brightside", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 3, Name = "Smile Like You Mean It", Length = new TimeSpan(0, 3, 54)},
                new Track {AlbumOrder = 4, Name = "Somebody Told Me", Length = new TimeSpan(0, 3, 17)},
                new Track {AlbumOrder = 5, Name = "All These Things That I've Done", Length = new TimeSpan(0, 5, 1)},
                new Track {AlbumOrder = 6, Name = "Andy, You're A Star", Length = new TimeSpan(0, 3, 14)},
                new Track {AlbumOrder = 7, Name = "On Top", Length = new TimeSpan(0, 4, 18)},
                new Track {AlbumOrder = 8, Name = "Change Your Mind", Length = new TimeSpan(0, 3, 11)},
                new Track {AlbumOrder = 9, Name = "Believe Me Natalie", Length = new TimeSpan(0, 5, 5)},
                new Track {AlbumOrder = 10, Name = "Midnight Show", Length = new TimeSpan(0, 4, 2)},
                new Track {AlbumOrder = 11, Name = "Everything Will Be Alrigh", Length = new TimeSpan(0, 5, 45)}
            };

            list.Add("Hot Fuss", hotFuss);

            var blackHolesAndRevelations = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Take A Bow", Length = new TimeSpan(0, 4, 35)},
                new Track {AlbumOrder = 2, Name = "Starlight", Length = new TimeSpan(0, 3, 59)},
                new Track {AlbumOrder = 3, Name = "Supermassive Black Hole", Length = new TimeSpan(0, 3, 29)},
                new Track {AlbumOrder = 4, Name = "Map of the Problematique", Length = new TimeSpan(0, 4, 18)},
                new Track {AlbumOrder = 5, Name = "Soldier's Poem", Length = new TimeSpan(0, 2, 3)},
                new Track {AlbumOrder = 6, Name = "Invincible", Length = new TimeSpan(0, 5, 0)},
                new Track {AlbumOrder = 7, Name = "Assassin", Length = new TimeSpan(0, 3, 31)},
                new Track {AlbumOrder = 8, Name = "Exo-Politics", Length = new TimeSpan(0, 3, 53)},
                new Track {AlbumOrder = 9, Name = "City of Delusion", Length = new TimeSpan(0, 4, 48)},
                new Track {AlbumOrder = 10, Name = "Hoodoo", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 11, Name = "Knights of Cydonia", Length = new TimeSpan(0, 6, 6)}
            };

            list.Add("Black Holes and Revelations", blackHolesAndRevelations);

            var echosSilencePatienceAndGraceTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "The Pretender", Length = new TimeSpan(0, 4, 29)},
                new Track {AlbumOrder = 2, Name = "Let it Die", Length = new TimeSpan(0, 4, 5)},
                new Track {AlbumOrder = 3, Name = "Erase/Replace", Length = new TimeSpan(0, 4, 13)},
                new Track {AlbumOrder = 4, Name = "Long Road to Ruin", Length = new TimeSpan(0, 3, 44)},
                new Track {AlbumOrder = 5, Name = "Come Alive", Length = new TimeSpan(0, 5, 10)},
                new Track {AlbumOrder = 6, Name = "Stranger Things Have Happened", Length = new TimeSpan(0, 5, 21)},
                new Track {AlbumOrder = 7, Name = "Cheer Up, Boys (Your Mak Up is Running)", Length = new TimeSpan(0, 3, 41)},
                new Track {AlbumOrder = 8, Name = "Summer's End", Length = new TimeSpan(0, 4, 37)},
                new Track {AlbumOrder = 9, Name = "Ballad of the Beaconsfield Miners", Length = new TimeSpan(0, 2, 32)},
                new Track {AlbumOrder = 10, Name = "Statues", Length = new TimeSpan(0, 3, 47)},
                new Track {AlbumOrder = 11, Name = "But, Honestly", Length = new TimeSpan(0, 4, 35)},
                new Track {AlbumOrder = 12, Name = "Home", Length = new TimeSpan(0, 4, 52)}
            };

            list.Add("Echos, Silence, Patience & Grace", echosSilencePatienceAndGraceTracks);

            var blackwaterParkTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "The Leper Affinity", Length = new TimeSpan(0, 10, 23)},
                new Track {AlbumOrder = 2, Name = "Bleak", Length = new TimeSpan(0, 9, 16)},
                new Track {AlbumOrder = 3, Name = "Harvest", Length = new TimeSpan(0, 6, 1)},
                new Track {AlbumOrder = 4, Name = "The Drapery Falls", Length = new TimeSpan(0, 10, 54)},
                new Track {AlbumOrder = 5, Name = "Dirge for November", Length = new TimeSpan(0, 7, 54)},
                new Track {AlbumOrder = 6, Name = "The Funeral Portrait", Length = new TimeSpan(0, 8, 44)},
                new Track {AlbumOrder = 7, Name = "Patterns in the Ivy", Length = new TimeSpan(0, 1, 53)},
                new Track {AlbumOrder = 8, Name = "Blackwater Park", Length = new TimeSpan(0, 12, 8)},
                new Track {AlbumOrder = 9, Name = "The Leper Affinity (live)", Length = new TimeSpan(0, 9, 24)}
            };
            list.Add("Blackwater Park", blackwaterParkTracks);
            
            var goTracks = new List<Track>
            {
            };
            list.Add("Go", goTracks);

           
            var theOffspringTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Time to Relax", Length = new TimeSpan(0, 0, 25)},
                new Track {AlbumOrder = 2, Name = "Nitro (Youth Energy)", Length = new TimeSpan(0, 2, 27)},
                new Track {AlbumOrder = 3, Name = "Bad Habit", Length = new TimeSpan(0, 3, 43)},
                new Track {AlbumOrder = 4, Name = "Gotta Get Away", Length = new TimeSpan(0, 3, 52)},
                new Track {AlbumOrder = 5, Name = "Genocide", Length = new TimeSpan(0, 3, 33)},
                new Track {AlbumOrder = 6, Name = "Something to Believe In", Length = new TimeSpan(0, 3, 17)},
                new Track {AlbumOrder = 7, Name = "Come Out and Play", Length = new TimeSpan(0, 3, 17)},
                new Track {AlbumOrder = 8, Name = "Self Esteem", Length = new TimeSpan(0, 4, 17)},
                new Track {AlbumOrder = 9, Name = "It'll be a Long Time", Length = new TimeSpan(0, 2, 43)},
                new Track {AlbumOrder = 10, Name = "Killboy Powerhead", Length = new TimeSpan(0, 2, 2)},
                new Track {AlbumOrder = 11, Name = "What Happened to You?", Length = new TimeSpan(0, 2, 12)},
                new Track {AlbumOrder = 12, Name = "So Alone", Length = new TimeSpan(0, 1, 17)},
                new Track {AlbumOrder = 13, Name = "Not the One", Length = new TimeSpan(0, 2, 54)},
                new Track {AlbumOrder = 14, Name = "Smash", Length = new TimeSpan(0, 10, 42)}
            };
            list.Add("The Offspring", theOffspringTracks);


            var brothersTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Everlasting Light`", Length = new TimeSpan(0, 3, 24)},
                new Track {AlbumOrder = 2, Name = "Next Girl", Length = new TimeSpan(0, 3, 18)},
                new Track {AlbumOrder = 3, Name = "Tighten Up", Length = new TimeSpan(0, 3, 31)},
                new Track {AlbumOrder = 4, Name = "Howlin' for You", Length = new TimeSpan(0, 3, 12)},
                new Track {AlbumOrder = 5, Name = "She's Long Gone", Length = new TimeSpan(0, 3, 6)},
                new Track {AlbumOrder = 6, Name = "Black Mud", Length = new TimeSpan(0, 2, 10)},
                new Track {AlbumOrder = 7, Name = "The Only One", Length = new TimeSpan(0, 5, 0)},
                new Track {AlbumOrder = 8, Name = "Too Afraid to Love You", Length = new TimeSpan(0, 3, 25)},
                new Track {AlbumOrder = 9, Name = "Ten Cent Pistol", Length = new TimeSpan(0, 4, 29)},
                new Track {AlbumOrder = 10, Name = "Sinister Kid", Length = new TimeSpan(0, 3, 45)},
                new Track {AlbumOrder = 11, Name = "The Go Getter", Length = new TimeSpan(0, 3, 37)},
                new Track {AlbumOrder = 12, Name = "I'm Not the One", Length = new TimeSpan(0, 3, 49)},
                new Track {AlbumOrder = 13, Name = "Unknown Brother", Length = new TimeSpan(0, 4, 0)},
                new Track {AlbumOrder = 14, Name = "Never Gonna Give You Up", Length = new TimeSpan(0, 3, 39)},
                new Track {AlbumOrder = 15, Name = "These Days", Length = new TimeSpan(0, 5, 12)}
            };
            list.Add("Brothers", brothersTracks);


            var howBigHowBlueHowBeautifulTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Ship to Wreck", Length = new TimeSpan(0, 3, 54)},
                new Track {AlbumOrder = 2, Name = "What Kind of Man", Length = new TimeSpan(0, 3, 36)},
                new Track {AlbumOrder = 3, Name = "How Big, How Blue, How Beautiful", Length = new TimeSpan(0, 5, 34)},
                new Track {AlbumOrder = 4, Name = "Queen of Peace", Length = new TimeSpan(0, 5, 7)},
                new Track {AlbumOrder = 5, Name = "Various Storms & Saints", Length = new TimeSpan(0, 4, 9)},
                new Track {AlbumOrder = 6, Name = "Delilah", Length = new TimeSpan(0, 4, 53)},
                new Track {AlbumOrder = 7, Name = "Long & Lost", Length = new TimeSpan(0, 3, 15)},
                new Track {AlbumOrder = 8, Name = "Caught", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 9, Name = "Third Eye", Length = new TimeSpan(0, 4, 20)},
                new Track {AlbumOrder = 10, Name = "St. Jude", Length = new TimeSpan(0, 3, 45)},
                new Track {AlbumOrder = 11, Name = "Mother", Length = new TimeSpan(0, 5, 49)}
            };
            list.Add("How Big, How Blue, How Beautiful", howBigHowBlueHowBeautifulTracks);


            var mezzanineTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Angel", Length = new TimeSpan(0, 8, 14)},
                new Track {AlbumOrder = 2, Name = "Risingson", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 3, Name = "Teardrop", Length = new TimeSpan(0, 8, 121)},
                new Track {AlbumOrder = 4, Name = "Inertia Creeps", Length = new TimeSpan(0, 5, 30)},
                new Track {AlbumOrder = 5, Name = "Exchange", Length = new TimeSpan(0, 9, 32)},
                new Track {AlbumOrder = 6, Name = "Dissolved Girl", Length = new TimeSpan(0, 7, 3)},
                new Track {AlbumOrder = 7, Name = "Man Next Door", Length = new TimeSpan(0, 2, 32)},
                new Track {AlbumOrder = 8, Name = "Black Milk", Length = new TimeSpan(0, 11, 30)},
                new Track {AlbumOrder = 9, Name = "Mezzanine", Length = new TimeSpan(0, 7, 3)},
                new Track {AlbumOrder = 10, Name = "Group Four", Length = new TimeSpan(0, 2, 32)},
                new Track {AlbumOrder = 11, Name = "(Exchange)", Length = new TimeSpan(0, 11, 30)}
            };
            list.Add("Mezzanine", mezzanineTracks);


            var songsAboutJaneTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Harder to Breathe", Length = new TimeSpan(0, 2, 55)},
                new Track {AlbumOrder = 2, Name = "This Love", Length = new TimeSpan(0, 4, 26)},
                new Track {AlbumOrder = 3, Name = "Shiver", Length = new TimeSpan(0, 3, 1)},
                new Track {AlbumOrder = 4, Name = "She Will Be Loved", Length = new TimeSpan(0, 4, 17)},
                new Track {AlbumOrder = 5, Name = "Tangled", Length = new TimeSpan(0, 3, 19)},
                new Track {AlbumOrder = 6, Name = "The Sun", Length = new TimeSpan(0, 4, 11)},
                new Track {AlbumOrder = 7, Name = "Must Get Out", Length = new TimeSpan(0, 4, 36)},
                new Track {AlbumOrder = 8, Name = "Sunday Morning", Length = new TimeSpan(0, 4, 6)},
                new Track {AlbumOrder = 9, Name = "Secret", Length = new TimeSpan(0, 4, 55)},
                new Track {AlbumOrder = 10, Name = "Through with You", Length = new TimeSpan(0, 3, 1)},
                new Track {AlbumOrder = 11, Name = "Not Coming Home", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 12, Name = "Sweetest Goodbye", Length = new TimeSpan(0, 4, 31)}
            };
            list.Add("Songs About Jane", songsAboutJaneTracks);


            var okComputerTracks = new List<Track>
            {
                new Track {AlbumOrder = 1, Name = "Airbag", Length = new TimeSpan(0, 4, 44)},
                new Track {AlbumOrder = 2, Name = "Paranoid Android", Length = new TimeSpan(0, 6, 23)},
                new Track {AlbumOrder = 3, Name = "Subterranean Homesick Alien", Length = new TimeSpan(0, 4, 27)},
                new Track {AlbumOrder = 4, Name = "Exit Music (For a Film)", Length = new TimeSpan(0, 4, 24)},
                new Track {AlbumOrder = 5, Name = "Let Down", Length = new TimeSpan(0, 4, 59)},
                new Track {AlbumOrder = 6, Name = "Karma Police", Length = new TimeSpan(0, 4, 21)},
                new Track {AlbumOrder = 7, Name = "Fitter Happier", Length = new TimeSpan(0, 1, 57)},
                new Track {AlbumOrder = 8, Name = "Electioneering", Length = new TimeSpan(0, 3, 50)},
                new Track {AlbumOrder = 9, Name = "Climbing Up the Walls", Length = new TimeSpan(0, 4, 45)},
                new Track {AlbumOrder = 10, Name = "No Suprises", Length = new TimeSpan(0, 3, 48)},
                new Track {AlbumOrder = 11, Name = "Lucky", Length = new TimeSpan(0, 4, 19)},
                new Track {AlbumOrder = 12, Name = "The Tourist", Length = new TimeSpan(0, 5, 24)}
            };
            list.Add("OK Computer", okComputerTracks);


            



            return list;
        }

        private static string[,] GetInitialData()
        {
            var albumArtistInfo = new string[25, 6];

            albumArtistInfo[0, 0] = "Clockwork Angles";
            albumArtistInfo[0, 1] = "6/8/2012";
            albumArtistInfo[0, 2] = "Rush_ClockworkAngles.png";
            albumArtistInfo[0, 3] = "Rush";
            albumArtistInfo[0, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[0, 5] = "Rush.jpg";
            

            albumArtistInfo[1, 0] = "Fear of a Blank Planet";
            albumArtistInfo[1, 1] = "4/16/2007";
            albumArtistInfo[1, 2] = "PorcupineTree_FearOfABlankPlanet.jpg";
            albumArtistInfo[1, 3] = "Porcupine Tree";
            albumArtistInfo[1, 4] = "Porcupine Tree are an English rock band formed by musician Steven Wilson in 1987. The band began essentially as a solo project for Wilson, who created all of the band's music. However, by 1993, Wilson desired to work in a band environment, and so brought on frequent collaborators Richard Barbieri on keyboards, Colin Edwin on bass and Chris Maitland on drums as permanent band members. With Wilson still in charge of guitar and lead vocals, this would remain the lineup until 2001, when the band recruited Gavin Harrison to replace Maitland on drums.";
            albumArtistInfo[1, 5] = "PorcupineTree.jpg";

            albumArtistInfo[2, 0] = "Hand. Cannot. Erase.";
            albumArtistInfo[2, 1] = "2/27/2015";
            albumArtistInfo[2, 2] = "StevenWilson_HandCannotErase.jpg";
            albumArtistInfo[2, 3] = "Steven Wilson";
            albumArtistInfo[2, 4] = "Steven John Wilson (born 3 November 1967) is an English musician and record producer, most associated with the progressive rock genre. Currently a critically acclaimed successful solo artist, he is well known as the founder, lead guitarist, singer and songwriter of the band Porcupine Tree, as well as being a member of several other bands. He has also worked with artists such as Opeth, King Crimson, Pendulum, Jethro Tull, XTC, Yes, Marillion, Orphaned Land and Anathema.";
            albumArtistInfo[2, 5] = "StevenWilson.jpg";

            albumArtistInfo[3, 0] = "A Momentary Lapse of Reason";
            albumArtistInfo[3, 1] = "9/7/1987";
            albumArtistInfo[3, 2] = "PinkFloyd_MomentaryLapseOfReason.jpg";
            albumArtistInfo[3, 3] = "Pink Floyd";
            albumArtistInfo[3, 4] = "Pink Floyd were an English rock band formed in London. They achieved international acclaim with their progressive and psychedelic music. Distinguished by their use of philosophical lyrics, sonic experimentation, extended compositions and elaborate live shows, they are one of the most commercially successful and musically influential groups in the history of popular music.";
            albumArtistInfo[3, 5] = "PinkFloyd.jpg";

            albumArtistInfo[4, 0] = "Saturday Night Fever Soundtrack";
            albumArtistInfo[4, 1] = "11/15/1977";
            albumArtistInfo[4, 2] = "BeeGees_SaturdayNightFever.jpg";
            albumArtistInfo[4, 3] = "Bee Gees";
            albumArtistInfo[4, 4] = "The Bee Gees were a pop music group formed in 1958. The group's line-up consisted of brothers Barry, Robin, and Maurice Gibb. The trio were successful for most of their decades of recording music, but they had two distinct periods of exceptional success: as a popular music act in the late 1960s and early 1970s, and as prominent performers of the disco music era in the late 1970s. The group sang recognisable three-part tight harmonies; Robin's clear vibrato lead vocals were a hallmark of their earlier hits, while Barry's R&B falsetto became their signature sound during the late 1970s and 1980s. They wrote all of their own hits, as well as writing and producing several major hits for other artists.";
            albumArtistInfo[4, 5] = "BeeGees.jpg";

            albumArtistInfo[5, 0] = "Life For Rent";
            albumArtistInfo[5, 1] = "9/29/2003";
            albumArtistInfo[5, 2] = "Dido_LifeForRent.png";
            albumArtistInfo[5, 3] = "Dido";
            albumArtistInfo[5, 4] = "Dido Florian Cloud de Bounevialle O'Malley Armstrong,[2] known as Dido (/ˈdaɪdoʊ/, born 25 December 1971), is a British singer and songwriter. Dido attained international success with her debut album No Angel (1999). It sold over 21 million copies worldwide,[3] and won several awards, including the MTV Europe Music Award for Best New Act, two NRJ Awards for Best New Act and Best Album, and two Brit Awards for Best British Female and Best Album. Her next album, Life for Rent (2003), continued her success with the hit singles White Flag and Life for Rent.";
            albumArtistInfo[5, 5] = "Dido.jpg";

            albumArtistInfo[6, 0] = "Save Rock and Roll";
            albumArtistInfo[6, 1] = "8/3/2015";
            albumArtistInfo[6, 2] = "FalloutBoy_SaveRockAndRoll.jpg";
            albumArtistInfo[6, 3] = "Fallout Boy";
            albumArtistInfo[6, 4] = "Fall Out Boy is an American rock band formed in Wilmette, Illinois, a suburb of Chicago, in 2001. The band consists of vocalist and guitarist Patrick Stump, bassist Pete Wentz, guitarist Joe Trohman, and drummer Andy Hurley. The band originated from Chicago's hardcore punk scene, with which Wentz was heavily involved. The group was formed by Wentz and Trohman as a pop punk side project of their respective hardcore bands, and Stump joined shortly thereafter. The group went through a succession of drummers before landing Hurley and recording their debut album, Take This to Your Grave (2003), which became an underground success and helped the band gain a dedicated fanbase through heavy touring, as well as some moderate commercial success.";
            albumArtistInfo[6, 5] = "FalloutBoy.jpg";


            albumArtistInfo[7, 0] = "Beyonce";
            albumArtistInfo[7, 1] = "8/3/2015";
            albumArtistInfo[7, 2] = "Beyonce_Beyonce.png";
            albumArtistInfo[7, 3] = "Beyonce";
            albumArtistInfo[7, 4] = "Beyoncé Giselle Knowles-Carter (born September 4, 1981) is an American singer, songwriter, and actress. Born and raised in Houston, Texas, she performed in various singing and dancing competitions as a child, and rose to fame in the late 1990s as lead singer of R&B girl-group Destiny's Child. Managed by her father Mathew Knowles, the group became one of the world's best-selling girl groups of all time. Their hiatus saw the release of Beyoncé's debut album, Dangerously in Love (2003), which established her as a solo artist worldwide; it sold 11 million copies, earned five Grammy Awards and featured the Billboard Hot 100 number-one singles Crazy in Love and Baby Boy.";
            albumArtistInfo[7, 5] = "Beyonce.jpg";

            albumArtistInfo[8, 0] = "1989";
            albumArtistInfo[8, 1] = "8/3/2015";
            albumArtistInfo[8, 2] = "TaylorSwift_1989.png";
            albumArtistInfo[8, 3] = "Taylor Swift";
            albumArtistInfo[8, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[8, 5] = "TaylorSwift.jpg";


            albumArtistInfo[9, 0] = "X";
            albumArtistInfo[9, 1] = "8/3/2015";
            albumArtistInfo[9, 2] = "EdSheeran_X.png";
            albumArtistInfo[9, 3] = "Ed Sheeran";
            albumArtistInfo[9, 4] = "Edward Christopher 'Ed' Sheeran (born 17 February 1991) is an English singer-songwriter and musician. Born in Hebden Bridge, West Yorkshire and raised in Framlingham, Suffolk, he moved to London in 2008 to pursue a musical career. In early 2011, Sheeran released an independent extended play, No. 5 Collaborations Project, which caught the attention of both Elton John and Jamie Foxx. He then signed to Asylum Records. His debut album, +, containing the singles The A Team and Lego House, was certified 6× Platinum in the UK. In 2012, Sheeran won two Brit Awards for Best British Male Solo Artist and British Breakthrough Act. The A Team won the Ivor Novello Award for Best Song Musically and Lyrically. In 2014, he was nominated for Best New Artist at the 56th Annual Grammy Awards.[1]";
            albumArtistInfo[9, 5] = "EdSheeran.jpg";

            albumArtistInfo[10, 0] = "A Night at the Opera";
            albumArtistInfo[10, 1] = "8/3/2015";
            albumArtistInfo[10, 2] = "Queen_ANightAtTheOpera.png";
            albumArtistInfo[10, 3] = "Queen";
            albumArtistInfo[10, 4] = "Queen are a British rock band formed in London in 1970. They originally consisted of Freddie Mercury (lead vocals, piano), Brian May (guitar, vocals), John Deacon (bass guitar), and Roger Taylor (drums, vocals). Queen's earliest works were influenced by progressive rock, hard rock and heavy metal, but the band gradually ventured into more conventional and radio-friendly works by incorporating further styles, such as arena rock and pop rock, into their music.";
            albumArtistInfo[10, 5] = "Queen.png";

            albumArtistInfo[11, 0] = "The Real Thing";
            albumArtistInfo[11, 1] = "8/3/2015";
            albumArtistInfo[11, 2] = "FaithNoMore_TheRealThing.jpg";
            albumArtistInfo[11, 3] = "Faith No More";
            albumArtistInfo[11, 4] = "Faith No More is an American rock band from San Francisco, California, formed in 1981. The band was originally named Faith No Man.[1] Bassist Billy Gould, keyboardist Roddy Bottum and drummer Mike Bordin are the longest remaining members of the band, having been involved with Faith No More since its inception. The band underwent several lineup changes early in their career, along with some major changes later on. The current version of Faith No More consists of Gould, Bottum, Bordin, guitarist Jon Hudson, and vocalist Mike Patton.";
            albumArtistInfo[11, 5] = "FaithNoMore.jpg";

            albumArtistInfo[12, 0] = "American Idiot";
            albumArtistInfo[12, 1] = "8/3/2015";
            albumArtistInfo[12, 2] = "GreenDay_AmericanIdiot.jpg";
            albumArtistInfo[12, 3] = "Green Day";
            albumArtistInfo[12, 4] = "Green Day is an American punk rock band formed in 1986 by vocalist/guitarist Billie Joe Armstrong and bassist Mike Dirnt. For much of their career, the band has been a trio with drummer Tré Cool, who replaced former drummer John Kiffmeyer in 1990 prior to the recording of the band's second studio album, Kerplunk (1992). In 2012, guitarist Jason White became a full-time member after having performed with the band as a session and touring member since 1999.";
            albumArtistInfo[12, 5] = "GreenDay.jpg";

            albumArtistInfo[13, 0] = "Hot Fuss";
            albumArtistInfo[13, 1] = "8/3/2015";
            albumArtistInfo[13, 2] = "Killers_HotFuss.jpg";
            albumArtistInfo[13, 3] = "The Killers";
            albumArtistInfo[13, 4] = "The Killers are an American rock band formed in Las Vegas, Nevada in 2001, by Brandon Flowers (lead vocals, keyboards) and Dave Keuning (guitar, backing vocals). Mark Stoermer (bass, backing vocals) and Ronnie Vannucci Jr. (drums, percussion) would complete the current line-up of the band in 2002. The name The Killers is derived from a logo on the bass drum of a fictitious band, portrayed in the music video for the New Order song Crystal.";
            albumArtistInfo[13, 5] = "TheKillers.jpg";

            albumArtistInfo[14, 0] = "Black Holes and Revelations";
            albumArtistInfo[14, 1] = "8/3/2015";
            albumArtistInfo[14, 2] = "Muse_BlackHolesAndRevelations.jpg";
            albumArtistInfo[14, 3] = "Muse";
            albumArtistInfo[14, 4] = "Muse are an English rock band from Teignmouth, Devon, formed in 1994. The band consists of Matthew Bellamy (lead vocals, guitar, piano, keyboards), Christopher Wolstenholme (bass guitar, backing vocals) and Dominic Howard (drums, percussion, synthesisers). They are known for their energetic live performances.[1][2]";
            albumArtistInfo[14, 5] = "Muse.jpg";

            albumArtistInfo[15, 0] = "Echos, Silence, Patience & Grace";
            albumArtistInfo[15, 1] = "8/3/2015";
            albumArtistInfo[15, 2] = "FooFighers_EchoesSilenePatienceAndGrace.jpg";
            albumArtistInfo[15, 3] = "Foo Fighters";
            albumArtistInfo[15, 4] = "Foo Fighters is an American rock band, formed in Seattle in 1994. It was founded by Nirvana drummer Dave Grohl as a one-man project following the death of Kurt Cobain and the resulting dissolution of his previous band. The group got its name from the UFOs and various aerial phenomena that were reported by Allied aircraft pilots in World War II, which were known collectively as foo fighters.";
            albumArtistInfo[15, 5] = "FooFighers.jpg";

            albumArtistInfo[16, 0] = "Blackwater Park";
            albumArtistInfo[16, 1] = "8/3/2015";
            albumArtistInfo[16, 2] = "Opeth_BlackwaterPark.jpg";
            albumArtistInfo[16, 3] = "Opeth";
            albumArtistInfo[16, 4] = "Opeth is a Swedish heavy metal band from Stockholm, formed in 1990. Though the group has been through several personnel changes, singer, guitarist, and songwriter Mikael Åkerfeldt has remained Opeth's driving force throughout the years. Opeth has consistently incorporated progressive, folk, blues, classical and jazz influences into their usually lengthy compositions, as well as strong influences from death metal, especially in their early works. Many songs include acoustic guitar passages and strong dynamic shifts, as well as both death growls and clean vocals. Opeth rarely made live appearances supporting their first four albums; but since conducting their first world tour after the 2001 release of Blackwater Park, they have led several major world tours.";
            albumArtistInfo[16, 5] = "Opeth.jpg";

            albumArtistInfo[17, 0] = "Go";
            albumArtistInfo[17, 1] = "8/3/2015";
            albumArtistInfo[17, 2] = "Moby_Go.jpg";
            albumArtistInfo[17, 3] = "Moby";
            albumArtistInfo[17, 4] =
                "Richard Melville Hall (born September 11, 1965),[1] better known by his stage name Moby, is an American singer-songwriter, musician, DJ and photographer. He is well known for his electronic music, vegan lifestyle, and support of animal rights. Moby has sold over 20 million albums worldwide.[2] AllMusic considers him one of the most important dance music figures of the early 1990s, helping bring the music to a mainstream audience both in the UK and in America.[3]";
            albumArtistInfo[17, 5] = "Moby.jpg";


            albumArtistInfo[18, 0] = "Smash";
            albumArtistInfo[18, 1] = "8/3/2015";
            albumArtistInfo[18, 2] = "Offspring_Smash.jpg";
            albumArtistInfo[18, 3] = "The Offspring";
            albumArtistInfo[18, 4] =
                "The Offspring is an American punk rock band from Huntington Beach, California, formed in 1984.[2] Formed under the name Manic Subsidal, the band consists of lead vocalist and rhythm guitarist Dexter Holland, bassist Greg K., lead guitarist Kevin 'Noodles' Wasserman and drummer Pete Parada. The Offspring is often credited—alongside fellow California punk bands Bad Religion, NOFX, Green Day, Rancid and Pennywise—for reviving mainstream interest in punk rock in the 1990s.[3][4] They have sold over 36 million records worldwide,[5][6] being considered one of the best-selling punk rock bands of all time.[7]";
            albumArtistInfo[18, 5] = "Offspring.jpg";

            albumArtistInfo[19, 0] = "Images and Words";
            albumArtistInfo[19, 1] = "8/3/2015";
            albumArtistInfo[19, 2] = "DreamTheater_ImagesAndWords.jpg";
            albumArtistInfo[19, 3] = "Dream Theater";
            albumArtistInfo[19, 4] =
                "Dream Theater is an American progressive metal and progressive rock band formed in 1985 under the name Majesty by John Petrucci, John Myung, and Mike Portnoy while they attended Berklee College of Music in Massachusetts. They subsequently dropped out of their studies to concentrate further on the band that would ultimately become Dream Theater. Though a number of lineup changes followed, the three original members remained together along with James LaBrie and Jordan Rudess until September 8, 2010 when Portnoy left the band. In October 2010, the band held auditions for a drummer to replace Portnoy. Mike Mangini was announced as the new permanent drummer on April 29, 2011.";
            albumArtistInfo[19, 5] = "DreamTheater.jpg";

            albumArtistInfo[20, 0] = "Brothers";
            albumArtistInfo[20, 1] = "8/3/2015";
            albumArtistInfo[20, 2] = "BlackKeys_Brothers.jpg";
            albumArtistInfo[20, 3] = "The Black Keys";
            albumArtistInfo[20, 4] =
                "The Black Keys are an American rock duo formed in Akron, Ohio, in 2001. The group consists of Dan Auerbach (guitar, vocals) and Patrick Carney (drums). The duo began as an independent act, recording music in basements and self-producing their records, before they eventually emerged as one of the most popular garage rock artists during a second wave of the genre's revival in the 2010s. The band's raw blues rock sound draws heavily from Auerbach's blues influences, including Junior Kimbrough, Howlin' Wolf, and Robert Johnson.";
            albumArtistInfo[20, 5] = "BlackKeys.jpg";

            albumArtistInfo[21, 0] = "How Big, How Blue, How Beautiful";
            albumArtistInfo[21, 1] = "8/3/2015";
            albumArtistInfo[21, 2] = "FlorenceAndTheMachine_HowBigHowBlueHowBeautiful.png";
            albumArtistInfo[21, 3] = "Florence + The Machine";
            albumArtistInfo[21, 4] =
                "Florence and the Machine (styled as Florence + the Machine)[4] are an English indie rock band that formed in London in 2007, consisting of lead singer Florence Welch, Isabella Summers, and a collaboration of other artists. The band's music received praise across the media, especially from the BBC, which played a large part in their rise to prominence by promoting Florence and the Machine as part of BBC Introducing. At the 2009 Brit Awards they received the Brit Awards Critics' Choice award. The band's music is renowned for its dramatic and eccentric production and also Welch's vocal performances.";
            albumArtistInfo[21, 5] = "FlorenceAndTheMachine.jpg";

            albumArtistInfo[22, 0] = "Mezzanine";
            albumArtistInfo[22, 1] = "8/3/2015";
            albumArtistInfo[22, 2] = "MassiveAttack_Mezzanine.png";
            albumArtistInfo[22, 3] = "Massive Attack";
            albumArtistInfo[22, 4] =
                "Massive Attack is an English musical group formed in 1988 in Bristol, consisting of Robert '3D' Del Naja and Grant 'Daddy G' Marshall. Their debut album Blue Lines was released in 1991, with the single 'Unfinished Sympathy' reaching the charts and later being voted the 63rd greatest song of all time in a poll by NME. 1998's Mezzanine, containing 'Teardrop', and 2003's 100th Window charted in the UK at number 1. Both Blue Lines and Mezzanine feature in Rolling Stone‍'​s list of the 500 Greatest Albums of All Time.";
            albumArtistInfo[22, 5] = "MassiveAttack.jpg";

            albumArtistInfo[23, 0] = "Songs About Jane";
            albumArtistInfo[23, 1] = "8/3/2015";
            albumArtistInfo[23, 2] = "Maroon5.jpg";
            albumArtistInfo[23, 3] = "Maroon 5";
            albumArtistInfo[23, 4] =
                "Maroon 5 is an American pop rock band that originated in Los Angeles, California. Before the group was formed the original four members of then 1994 band were known as Kara's Flowers while its members were still in high school and originally consisted of Adam Levine (lead vocals, guitar), Jesse Carmichael (guitar, backing vocals) Mickey Madden (bass guitar) and Ryan Dusick (drums). The band, which self-released an album called We Like Digging?, was named after a girl the group had a crush on. They signed to Reprise Records and released an album, The Fourth World, in 1997. After a tepid response to the album, the band parted ways with the record label and the members attended college.";
            albumArtistInfo[23, 5] = "Maroon5_SongsAboutJane.png";

            albumArtistInfo[24, 0] = "OK Computer";
            albumArtistInfo[24, 1] = "8/3/2015";
            albumArtistInfo[24, 2] = "Radiohead_OKComputer.jpg";
            albumArtistInfo[24, 3] = "Radiohead";
            albumArtistInfo[24, 4] =
                "Radiohead are an English rock band from Abingdon, Oxfordshire, formed in 1985. The band consists of Thom Yorke (lead vocals, guitar, piano), Jonny Greenwood (lead guitar, keyboards, other instruments), Colin Greenwood (bass), Phil Selway (drums, percussion, backing vocals) and Ed O'Brien (guitar, backing vocals).";
            albumArtistInfo[24, 5] = "Radiohead.jpg";
            return albumArtistInfo;
        }
    }
}