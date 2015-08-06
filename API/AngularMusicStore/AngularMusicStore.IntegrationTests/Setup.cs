﻿using System;
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
       // [Test]
        public void PrimeDatabaseWithOneArtistWithOneAlbum()
        {
            var kernel = new StandardKernel(new DomainModule());
            var artistService = kernel.Get<IArtistService>();

            var albumArtistInfo = GetInitialData();

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

                artist.AddAlbum(album);
                var result = artistService.Save(artist);
                artist = artistService.GetById(result);
                Assert.IsNotNull(artist);
            }
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
            albumArtistInfo[1, 1] = "8/3/2015";
            albumArtistInfo[1, 2] = "PorcupineTree_FearOfABlankPlanet.jpg";
            albumArtistInfo[1, 3] = "Porcupine Tree";
            albumArtistInfo[1, 4] = "Porcupine Tree are an English rock band formed by musician Steven Wilson in 1987. The band began essentially as a solo project for Wilson, who created all of the band's music. However, by 1993, Wilson desired to work in a band environment, and so brought on frequent collaborators Richard Barbieri on keyboards, Colin Edwin on bass and Chris Maitland on drums as permanent band members. With Wilson still in charge of guitar and lead vocals, this would remain the lineup until 2001, when the band recruited Gavin Harrison to replace Maitland on drums.";
            albumArtistInfo[1, 5] = "PorcupineTree.jpg";

            albumArtistInfo[2, 0] = "Hand. Cannot. Erase.";
            albumArtistInfo[2, 1] = "8/3/2015";
            albumArtistInfo[2, 2] = "StevenWilson_HandCannotErase.jpg";
            albumArtistInfo[2, 3] = "Steven Wilson";
            albumArtistInfo[2, 4] = "Steven John Wilson (born 3 November 1967) is an English musician and record producer, most associated with the progressive rock genre. Currently a critically acclaimed successful solo artist, he is well known as the founder, lead guitarist, singer and songwriter of the band Porcupine Tree, as well as being a member of several other bands. He has also worked with artists such as Opeth, King Crimson, Pendulum, Jethro Tull, XTC, Yes, Marillion, Orphaned Land and Anathema.";
            albumArtistInfo[2, 5] = "StevenWilson.jpg";

            albumArtistInfo[3, 0] = "A Momentary Lapse of Reason";
            albumArtistInfo[3, 1] = "8/3/2015";
            albumArtistInfo[3, 2] = "PinkFloyd_MomentaryLapseOfReason.jpg";
            albumArtistInfo[3, 3] = "Pink Floyd";
            albumArtistInfo[3, 4] = "Pink Floyd were an English rock band formed in London. They achieved international acclaim with their progressive and psychedelic music. Distinguished by their use of philosophical lyrics, sonic experimentation, extended compositions and elaborate live shows, they are one of the most commercially successful and musically influential groups in the history of popular music.";
            albumArtistInfo[3, 5] = "PinkFloyd.jpg";

            albumArtistInfo[4, 0] = "Saturday Night Fever Soundtrack";
            albumArtistInfo[4, 1] = "8/3/2015";
            albumArtistInfo[4, 2] = "BeeGees_SaturdayNightFever.jpg";
            albumArtistInfo[4, 3] = "Bee Gees";
            albumArtistInfo[4, 4] = "The Bee Gees were a pop music group formed in 1958. The group's line-up consisted of brothers Barry, Robin, and Maurice Gibb. The trio were successful for most of their decades of recording music, but they had two distinct periods of exceptional success: as a popular music act in the late 1960s and early 1970s, and as prominent performers of the disco music era in the late 1970s. The group sang recognisable three-part tight harmonies; Robin's clear vibrato lead vocals were a hallmark of their earlier hits, while Barry's R&B falsetto became their signature sound during the late 1970s and 1980s. They wrote all of their own hits, as well as writing and producing several major hits for other artists.";
            albumArtistInfo[4, 5] = "BeeGees.jpg";

            albumArtistInfo[5, 0] = "Life For Rent";
            albumArtistInfo[5, 1] = "8/3/2015";
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
            albumArtistInfo[17, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[17, 3] = "Moby";
            albumArtistInfo[17, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[17, 5] = "band.jpg";


            albumArtistInfo[18, 0] = "The Offspring";
            albumArtistInfo[18, 1] = "8/3/2015";
            albumArtistInfo[18, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[18, 3] = "Offspring";
            albumArtistInfo[18, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[18, 5] = "band.jpg";

            albumArtistInfo[19, 0] = "Images and Words";
            albumArtistInfo[19, 1] = "8/3/2015";
            albumArtistInfo[19, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[19, 3] = "Dream Theater";
            albumArtistInfo[19, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[19, 5] = "band.jpg";

            albumArtistInfo[20, 0] = "Brothers";
            albumArtistInfo[20, 1] = "8/3/2015";
            albumArtistInfo[20, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[20, 3] = "The Black Keys";
            albumArtistInfo[20, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[20, 5] = "band.jpg";

            albumArtistInfo[21, 0] = "How Big, How Blue, How Beautiful";
            albumArtistInfo[21, 1] = "8/3/2015";
            albumArtistInfo[21, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[21, 3] = "Florence + The Machine";
            albumArtistInfo[21, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[21, 5] = "band.jpg";

            albumArtistInfo[22, 0] = "Mezzanine";
            albumArtistInfo[22, 1] = "8/3/2015";
            albumArtistInfo[22, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[22, 3] = "Massive Attack";
            albumArtistInfo[22, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[22, 5] = "band.jpg";

            albumArtistInfo[23, 0] = "Songs About Jane";
            albumArtistInfo[23, 1] = "8/3/2015";
            albumArtistInfo[23, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[23, 3] = "Maroon 5";
            albumArtistInfo[23, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[23, 5] = "band.jpg";

            albumArtistInfo[24, 0] = "OK Computer";
            albumArtistInfo[24, 1] = "8/3/2015";
            albumArtistInfo[24, 2] = "LobsterKnifeFight.jpg";
            albumArtistInfo[24, 3] = "Radiohead";
            albumArtistInfo[24, 4] =
                "Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.";
            albumArtistInfo[24, 5] = "band.jpg";
            return albumArtistInfo;
        }
    }
}