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
            albumArtistInfo[0, 1] = "6/8/2012";
            albumArtistInfo[0, 2] = "Rush_ClockworkAngles.png";
            albumArtistInfo[0, 3] = "Rush";
            albumArtistInfo[0, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[0, 5] = "band.jpg";

            albumArtistInfo[1, 0] = "Fear of a Blank Planet";
            albumArtistInfo[1, 1] = "8/3/2015";
            albumArtistInfo[1, 2] = "PorcupineTree_FearOfABlankPlanet.jpg";
            albumArtistInfo[1, 3] = "Porcupine Tree";
            albumArtistInfo[1, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[1, 5] = "band.jpg";

            albumArtistInfo[2, 0] = "Hand. Cannot. Erase.";
            albumArtistInfo[2, 1] = "8/3/2015";
            albumArtistInfo[2, 2] = "StevenWilson_HandCannotErase.jpg";
            albumArtistInfo[2, 3] = "Steven Wilson";
            albumArtistInfo[2, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[2, 5] = "band.jpg";

            albumArtistInfo[3, 0] = "A Momentary Lapse of Reason";
            albumArtistInfo[3, 1] = "8/3/2015";
            albumArtistInfo[3, 2] = "PinkFloyd_MomentaryLapseOfReason.jpg";
            albumArtistInfo[3, 3] = "Pink Floyd";
            albumArtistInfo[3, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[3, 5] = "band.jpg";

            albumArtistInfo[4, 0] = "Saturday Night Fever Soundtrack";
            albumArtistInfo[4, 1] = "8/3/2015";
            albumArtistInfo[4, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[4, 3] = "Bee Gees";
            albumArtistInfo[4, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[4, 5] = "band.jpg";

            albumArtistInfo[5, 0] = "Life For Rent";
            albumArtistInfo[5, 1] = "8/3/2015";
            albumArtistInfo[5, 2] = "Dido_LifeForRent.png";
            albumArtistInfo[5, 3] = "Dido";
            albumArtistInfo[5, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[5, 5] = "band.jpg";

            albumArtistInfo[6, 0] = "Save Rock and Roll";
            albumArtistInfo[6, 1] = "8/3/2015";
            albumArtistInfo[6, 2] = "FalloutBoy_SaveRockAndRoll.jpg";
            albumArtistInfo[6, 3] = "Fallout Boy";
            albumArtistInfo[6, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[6, 5] = "band.jpg";


            albumArtistInfo[7, 0] = "Beyonce";
            albumArtistInfo[7, 1] = "8/3/2015";
            albumArtistInfo[7, 2] = "Beyonce_Beyonce.png";
            albumArtistInfo[7, 3] = "Beyonce";
            albumArtistInfo[7, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[7, 5] = "band.jpg";

            albumArtistInfo[8, 0] = "1989";
            albumArtistInfo[8, 1] = "8/3/2015";
            albumArtistInfo[8, 2] = "TaylorSwift_1989.png";
            albumArtistInfo[8, 3] = "Taylor Swift";
            albumArtistInfo[8, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[8, 5] = "band.jpg";


            albumArtistInfo[9, 0] = "X";
            albumArtistInfo[9, 1] = "8/3/2015";
            albumArtistInfo[9, 2] = "EdSheeran_X.png";
            albumArtistInfo[9, 3] = "Ed Sheeran";
            albumArtistInfo[9, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[9, 5] = "band.jpg";

            albumArtistInfo[10, 0] = "A Night at the Opera";
            albumArtistInfo[10, 1] = "8/3/2015";
            albumArtistInfo[10, 2] = "Queen_ANightAtTheOpera.png";
            albumArtistInfo[10, 3] = "Queen";
            albumArtistInfo[10, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[10, 5] = "band.jpg";


            albumArtistInfo[11, 0] = "The Real Thing";
            albumArtistInfo[11, 1] = "8/3/2015";
            albumArtistInfo[11, 2] = "FaithNoMore_TheRealThing.jpg";
            albumArtistInfo[11, 3] = "Faith No More";
            albumArtistInfo[11, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[11, 5] = "band.jpg";

            albumArtistInfo[12, 0] = "American Idiot";
            albumArtistInfo[12, 1] = "8/3/2015";
            albumArtistInfo[12, 2] = "GreenDay_AmericanIdiot.jpg";
            albumArtistInfo[12, 3] = "Green Day";
            albumArtistInfo[12, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[12, 5] = "band.jpg";


            albumArtistInfo[13, 0] = "Hot Fuss";
            albumArtistInfo[13, 1] = "8/3/2015";
            albumArtistInfo[13, 2] = "Killers_HotFuss.jpg";
            albumArtistInfo[13, 3] = "The Killers";
            albumArtistInfo[13, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[13, 5] = "band.jpg";

            albumArtistInfo[14, 0] = "Black Holes and Revelations";
            albumArtistInfo[14, 1] = "8/3/2015";
            albumArtistInfo[14, 2] = "Muse_BlackHolesAndRevelations.jpg";
            albumArtistInfo[14, 3] = "Muse";
            albumArtistInfo[14, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[14, 5] = "band.jpg";

            albumArtistInfo[15, 0] = "Echos, Silence, Patience & Grace";
            albumArtistInfo[15, 1] = "8/3/2015";
            albumArtistInfo[15, 2] = "FooFighers_EchoesSilenePatienceAndGrace.jpg";
            albumArtistInfo[15, 3] = "Foo Fighters";
            albumArtistInfo[15, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[15, 5] = "band.jpg";


            albumArtistInfo[16, 0] = "Blackwater Park";
            albumArtistInfo[16, 1] = "8/3/2015";
            albumArtistInfo[16, 2] = "Opeth_BlackwaterPark.jpg";
            albumArtistInfo[16, 3] = "Opeth";
            albumArtistInfo[16, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[16, 5] = "band.jpg";

            albumArtistInfo[17, 0] = "Go";
            albumArtistInfo[17, 1] = "8/3/2015";
            albumArtistInfo[17, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[17, 3] = "Moby";
            albumArtistInfo[17, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[17, 5] = "band.jpg";


            albumArtistInfo[18, 0] = "The Offspring";
            albumArtistInfo[18, 1] = "8/3/2015" ;
            albumArtistInfo[18, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[18, 3] = "Offspring";
            albumArtistInfo[18, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[18, 5] = "band.jpg";

            albumArtistInfo[19, 0] = "Images and Words";
            albumArtistInfo[19, 1] = "8/3/2015";
            albumArtistInfo[19, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[19, 3] = "Dream Theater";
            albumArtistInfo[19, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[19, 5] = "band.jpg";

            albumArtistInfo[20, 0] = "Brothers";
            albumArtistInfo[20, 1] = "8/3/2015";
            albumArtistInfo[20, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[20, 3] = "The Black Keys";
            albumArtistInfo[20, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[20, 5] = "band.jpg";

            albumArtistInfo[21, 0] = "How Big, How Blue, How Beautiful";
            albumArtistInfo[21, 1] = "8/3/2015";
            albumArtistInfo[21, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[21, 3] = "Florence + The Machine"   ;
            albumArtistInfo[21, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[21, 5] = "band.jpg";

            albumArtistInfo[22, 0] = "Mezzanine";
            albumArtistInfo[22, 1] = "8/3/2015";
            albumArtistInfo[22, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[22, 3] = "Massive Attack";
            albumArtistInfo[22, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[22, 5] = "band.jpg";

            albumArtistInfo[23, 0] = "Songs About Jane";
            albumArtistInfo[23, 1] = "8/3/2015";
            albumArtistInfo[23, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[23, 3] = "Maroon 5";
            albumArtistInfo[23, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[23, 5] = "band.jpg";

            albumArtistInfo[24, 0] = "OK Computer";
            albumArtistInfo[24, 1] = "8/3/2015";
            albumArtistInfo[24, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[24, 3] = "Radiohead";
            albumArtistInfo[24, 4] = "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[24, 5] = "band.jpg";




            albums.Add(new Album {Name = "Clockwork Angles", ReleaseDate = DateTime.Now.AddYears(-2), CoverUri = "LobsterKnifeFight.jpg"});
            artists.Add(new Artist {Name = "Rush", Bio = "They are from Canada. They are alright I guess", PictureUrl = "band.jpg"});


            artist.AddAlbum(album);
            var result = artistService.Save(artist);
            artist = artistService.GetById(result);
            Assert.IsNotNull(artist);
        }
    }
}