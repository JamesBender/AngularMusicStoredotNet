describe('controllers', function(){
	var scope, $httpBackend, controller;
	var queryResponseForArtistNameU = [{"$id":"1","Id":"a82ac00f-5b46-4347-925f-a46400de32be","Name":"Rush","Albums":[{"$id":"2","Id":"e8aeeb75-8d41-4340-a7a6-a46400de32d0","Name":"Clockwork Angles","ReleaseDate":"2013-03-23T13:28:59","CoverUri":null,"Parent":{"$ref":"1"}}]}];

	var queryResponseforAllArtists = [{"$id":"1","Id":"a70cb20e-8872-4b68-b1f9-a4ea0103bf70","Name":"Bee Gees","Albums":[{"$id":"2","Id":"12537007-9796-4da1-bd47-a4ea0103bf70","Name":"Saturday Night Fever Soundtrack","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/BeeGees_SaturdayNightFever.jpg","Parent":{"$ref":"1"}}],"Bio":"The Bee Gees were a pop music group formed in 1958. The group's line-up consisted of brothers Barry, Robin, and Maurice Gibb. The trio were successful for most of their decades of recording music, but they had two distinct periods of exceptional success: as a popular music act in the late 1960s and early 1970s, and as prominent performers of the disco music era in the late 1970s. The group sang recognisable three-part tight harmonies; Robin's clear vibrato lead vocals were a hallmark of their earlier hits, while Barry's R&B falsetto became their signature sound during the late 1970s and 1980s. They wrote all of their own hits, as well as writing and producing several major hits for other artists.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/BeeGees.jpg","RelatedArtists":[]},{"$id":"3","Id":"41311f37-9a12-40da-b0f9-a4ea0103bf74","Name":"Beyonce","Albums":[{"$id":"4","Id":"8ef2c2f8-d6b8-4ebf-9462-a4ea0103bf74","Name":"Beyonce","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Beyonce_Beyonce.png","Parent":{"$ref":"3"}}],"Bio":"Beyoncé Giselle Knowles-Carter (born September 4, 1981) is an American singer, songwriter, and actress. Born and raised in Houston, Texas, she performed in various singing and dancing competitions as a child, and rose to fame in the late 1990s as lead singer of R&B girl-group Destiny's Child. Managed by her father Mathew Knowles, the group became one of the world's best-selling girl groups of all time. Their hiatus saw the release of Beyoncé's debut album, Dangerously in Love (2003), which established her as a solo artist worldwide; it sold 11 million copies, earned five Grammy Awards and featured the Billboard Hot 100 number-one singles Crazy in Love and Baby Boy.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Beyonce.jpg","RelatedArtists":[]},{"$id":"5","Id":"cf1fd180-596b-4cdf-b3fe-a4ea0103bf71","Name":"Dido","Albums":[{"$id":"6","Id":"a99ef2c2-2d05-461d-a044-a4ea0103bf71","Name":"Life For Rent","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Dido_LifeForRent.png","Parent":{"$ref":"5"}}],"Bio":"Dido Florian Cloud de Bounevialle O'Malley Armstrong,[2] known as Dido (/ˈdaɪdoʊ/, born 25 December 1971), is a British singer and songwriter. Dido attained international success with her debut album No Angel (1999). It sold over 21 million copies worldwide,[3] and won several awards, including the MTV Europe Music Award for Best New Act, two NRJ Awards for Best New Act and Best Album, and two Brit Awards for Best British Female and Best Album. Her next album, Life for Rent (2003), continued her success with the hit singles White Flag and Life for Rent.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Dido.jpg","RelatedArtists":[]},{"$id":"7","Id":"f75fea9a-4023-472b-97d6-a4ea0103bf7f","Name":"Dream Theater","Albums":[{"$id":"8","Id":"582b537d-f71a-4274-b366-a4ea0103bf7f","Name":"Images and Words","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"7"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"9","Id":"5b65e632-f1b0-4c87-bc6f-a4ea0103bf75","Name":"Ed Sheeran","Albums":[{"$id":"10","Id":"e2633e1a-8eab-4b15-bd31-a4ea0103bf75","Name":"X","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/EdSheeran_X.png","Parent":{"$ref":"9"}}],"Bio":"Edward Christopher 'Ed' Sheeran (born 17 February 1991) is an English singer-songwriter and musician. Born in Hebden Bridge, West Yorkshire and raised in Framlingham, Suffolk, he moved to London in 2008 to pursue a musical career. In early 2011, Sheeran released an independent extended play, No. 5 Collaborations Project, which caught the attention of both Elton John and Jamie Foxx. He then signed to Asylum Records. His debut album, +, containing the singles The A Team and Lego House, was certified 6× Platinum in the UK. In 2012, Sheeran won two Brit Awards for Best British Male Solo Artist and British Breakthrough Act. The A Team won the Ivor Novello Award for Best Song Musically and Lyrically. In 2014, he was nominated for Best New Artist at the 56th Annual Grammy Awards.[1]","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/EdSheeran.jpg","RelatedArtists":[]},{"$id":"11","Id":"c4f82c28-702c-42a3-a1d0-a4ea0103bf77","Name":"Faith No More","Albums":[{"$id":"12","Id":"9357bd18-c870-481c-b094-a4ea0103bf77","Name":"The Real Thing","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/FaithNoMore_TheRealThing.jpg","Parent":{"$ref":"11"}}],"Bio":"Faith No More is an American rock band from San Francisco, California, formed in 1981. The band was originally named Faith No Man.[1] Bassist Billy Gould, keyboardist Roddy Bottum and drummer Mike Bordin are the longest remaining members of the band, having been involved with Faith No More since its inception. The band underwent several lineup changes early in their career, along with some major changes later on. The current version of Faith No More consists of Gould, Bottum, Bordin, guitarist Jon Hudson, and vocalist Mike Patton.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/FaithNoMore.jpg","RelatedArtists":[]},{"$id":"13","Id":"df3425b6-609e-46e0-a90f-a4ea0103bf73","Name":"Fallout Boy","Albums":[{"$id":"14","Id":"54f1c091-7ee3-4c22-b534-a4ea0103bf73","Name":"Save Rock and Roll","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/FalloutBoy_SaveRockAndRoll.jpg","Parent":{"$ref":"13"}}],"Bio":"Fall Out Boy is an American rock band formed in Wilmette, Illinois, a suburb of Chicago, in 2001. The band consists of vocalist and guitarist Patrick Stump, bassist Pete Wentz, guitarist Joe Trohman, and drummer Andy Hurley. The band originated from Chicago's hardcore punk scene, with which Wentz was heavily involved. The group was formed by Wentz and Trohman as a pop punk side project of their respective hardcore bands, and Stump joined shortly thereafter. The group went through a succession of drummers before landing Hurley and recording their debut album, Take This to Your Grave (2003), which became an underground success and helped the band gain a dedicated fanbase through heavy touring, as well as some moderate commercial success.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/FalloutBoy.jpg","RelatedArtists":[]},{"$id":"15","Id":"6741b064-7de1-4acf-8233-a4ea0103bf80","Name":"Florence + The Machine","Albums":[{"$id":"16","Id":"53ff00e2-68e5-41a0-a839-a4ea0103bf80","Name":"How Big, How Blue, How Beautiful","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"15"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"17","Id":"4c103433-a50b-4add-9062-a4ea0103bf7b","Name":"Foo Fighters","Albums":[{"$id":"18","Id":"71fba019-be04-4075-9078-a4ea0103bf7b","Name":"Echos, Silence, Patience & Grace","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/FooFighers_EchoesSilenePatienceAndGrace.jpg","Parent":{"$ref":"17"}}],"Bio":"Foo Fighters is an American rock band, formed in Seattle in 1994. It was founded by Nirvana drummer Dave Grohl as a one-man project following the death of Kurt Cobain and the resulting dissolution of his previous band. The group got its name from the UFOs and various aerial phenomena that were reported by Allied aircraft pilots in World War II, which were known collectively as foo fighters.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/FooFighers.jpg","RelatedArtists":[]},{"$id":"19","Id":"d2a9d9d9-b0d4-4baa-8ad1-a4ea0103bf78","Name":"Green Day","Albums":[{"$id":"20","Id":"2d548767-dadf-46d8-962c-a4ea0103bf78","Name":"American Idiot","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/GreenDay_AmericanIdiot.jpg","Parent":{"$ref":"19"}}],"Bio":"Green Day is an American punk rock band formed in 1986 by vocalist/guitarist Billie Joe Armstrong and bassist Mike Dirnt. For much of their career, the band has been a trio with drummer Tré Cool, who replaced former drummer John Kiffmeyer in 1990 prior to the recording of the band's second studio album, Kerplunk (1992). In 2012, guitarist Jason White became a full-time member after having performed with the band as a session and touring member since 1999.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/GreenDay.jpg","RelatedArtists":[]},{"$id":"21","Id":"0c03d47e-7425-48b9-9727-a4ea0103bf83","Name":"Maroon 5","Albums":[{"$id":"22","Id":"273d3247-3b6d-42f6-918e-a4ea0103bf83","Name":"Songs About Jane","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"21"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"23","Id":"cd2a1e4f-75e6-44c5-818e-a4ea0103bf82","Name":"Massive Attack","Albums":[{"$id":"24","Id":"bff3ca7b-7a39-4e32-b8c4-a4ea0103bf82","Name":"Mezzanine","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"23"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"25","Id":"24e7894e-13ff-400d-a253-a4ea0103bf7d","Name":"Moby","Albums":[{"$id":"26","Id":"7e55ecda-b6d2-4104-8d68-a4ea0103bf7d","Name":"Go","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"25"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"27","Id":"fe597db2-f224-45a2-b708-a4ea0103bf7a","Name":"Muse","Albums":[{"$id":"28","Id":"b411fa08-b20e-4025-948d-a4ea0103bf7a","Name":"Black Holes and Revelations","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Muse_BlackHolesAndRevelations.jpg","Parent":{"$ref":"27"}}],"Bio":"Muse are an English rock band from Teignmouth, Devon, formed in 1994. The band consists of Matthew Bellamy (lead vocals, guitar, piano, keyboards), Christopher Wolstenholme (bass guitar, backing vocals) and Dominic Howard (drums, percussion, synthesisers). They are known for their energetic live performances.[1][2]","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Muse.jpg","RelatedArtists":[]},{"$id":"29","Id":"7a570b97-d568-4a8a-9c6e-a4ea0103bf7e","Name":"Offspring","Albums":[{"$id":"30","Id":"b3ce7ca1-ceca-48e4-bce6-a4ea0103bf7e","Name":"The Offspring","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"29"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"31","Id":"1d7d9194-142c-478e-9097-a4ea0103bf7c","Name":"Opeth","Albums":[{"$id":"32","Id":"0ad12a6b-0c99-42ff-ae0d-a4ea0103bf7c","Name":"Blackwater Park","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Opeth_BlackwaterPark.jpg","Parent":{"$ref":"31"}}],"Bio":"Opeth is a Swedish heavy metal band from Stockholm, formed in 1990. Though the group has been through several personnel changes, singer, guitarist, and songwriter Mikael Åkerfeldt has remained Opeth's driving force throughout the years. Opeth has consistently incorporated progressive, folk, blues, classical and jazz influences into their usually lengthy compositions, as well as strong influences from death metal, especially in their early works. Many songs include acoustic guitar passages and strong dynamic shifts, as well as both death growls and clean vocals. Opeth rarely made live appearances supporting their first four albums; but since conducting their first world tour after the 2001 release of Blackwater Park, they have led several major world tours.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Opeth.jpg","RelatedArtists":[]},{"$id":"33","Id":"ac9d0407-63ba-4d2b-a654-a4ea0103bf6f","Name":"Pink Floyd","Albums":[{"$id":"34","Id":"b0901b04-6d9b-490e-bf23-a4ea0103bf6f","Name":"A Momentary Lapse of Reason","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/PinkFloyd_MomentaryLapseOfReason.jpg","Parent":{"$ref":"33"}}],"Bio":"Pink Floyd were an English rock band formed in London. They achieved international acclaim with their progressive and psychedelic music. Distinguished by their use of philosophical lyrics, sonic experimentation, extended compositions and elaborate live shows, they are one of the most commercially successful and musically influential groups in the history of popular music.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/PinkFloyd.jpg","RelatedArtists":[]},{"$id":"35","Id":"6c9b3014-3e29-45d2-8ba3-a4ea0103bf6d","Name":"Porcupine Tree","Albums":[{"$id":"36","Id":"a2c2957f-67ec-4a3a-9b86-a4ea0103bf6d","Name":"Fear of a Blank Planet","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/PorcupineTree_FearOfABlankPlanet.jpg","Parent":{"$ref":"35"}}],"Bio":"Porcupine Tree are an English rock band formed by musician Steven Wilson in 1987. The band began essentially as a solo project for Wilson, who created all of the band's music. However, by 1993, Wilson desired to work in a band environment, and so brought on frequent collaborators Richard Barbieri on keyboards, Colin Edwin on bass and Chris Maitland on drums as permanent band members. With Wilson still in charge of guitar and lead vocals, this would remain the lineup until 2001, when the band recruited Gavin Harrison to replace Maitland on drums.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/PorcupineTree.jpg","RelatedArtists":[]},{"$id":"37","Id":"4d197c91-ef05-4258-b323-a4ea0103bf76","Name":"Queen","Albums":[{"$id":"38","Id":"6f24ee4f-4ba1-4f44-8117-a4ea0103bf76","Name":"A Night at the Opera","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Queen_ANightAtTheOpera.png","Parent":{"$ref":"37"}}],"Bio":"Queen are a British rock band formed in London in 1970. They originally consisted of Freddie Mercury (lead vocals, piano), Brian May (guitar, vocals), John Deacon (bass guitar), and Roger Taylor (drums, vocals). Queen's earliest works were influenced by progressive rock, hard rock and heavy metal, but the band gradually ventured into more conventional and radio-friendly works by incorporating further styles, such as arena rock and pop rock, into their music.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Queen.png","RelatedArtists":[]},{"$id":"39","Id":"aa0f9ee4-009e-4e55-85e3-a4ea0103bf05","Name":"Rush","Albums":[{"$id":"40","Id":"28c33976-e9e0-4437-bf6f-a4ea0103bf0e","Name":"Clockwork Angles","ReleaseDate":"2012-06-08T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Rush_ClockworkAngles.png","Parent":{"$ref":"39"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/Rush.jpg","RelatedArtists":[]},{"$id":"41","Id":"a7ef6679-fdc8-4e06-8970-a4ea0103bf6e","Name":"Steven Wilson","Albums":[{"$id":"42","Id":"918a1e8c-03b0-4be8-9f18-a4ea0103bf6e","Name":"Hand. Cannot. Erase.","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/StevenWilson_HandCannotErase.jpg","Parent":{"$ref":"41"}}],"Bio":"Steven John Wilson (born 3 November 1967) is an English musician and record producer, most associated with the progressive rock genre. Currently a critically acclaimed successful solo artist, he is well known as the founder, lead guitarist, singer and songwriter of the band Porcupine Tree, as well as being a member of several other bands. He has also worked with artists such as Opeth, King Crimson, Pendulum, Jethro Tull, XTC, Yes, Marillion, Orphaned Land and Anathema.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/StevenWilson.jpg","RelatedArtists":[]},{"$id":"43","Id":"c81de96d-21b2-4775-a568-a4ea0103bf74","Name":"Taylor Swift","Albums":[{"$id":"44","Id":"82f42bb2-33a5-46e7-a73b-a4ea0103bf74","Name":"1989","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/TaylorSwift_1989.png","Parent":{"$ref":"43"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/TaylorSwift.jpg","RelatedArtists":[]},{"$id":"45","Id":"609d9a74-20ec-4cf3-ae06-a4ea0103bf80","Name":"The Black Keys","Albums":[{"$id":"46","Id":"c8f065a7-6ec0-4f1d-bbf2-a4ea0103bf80","Name":"Brothers","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/LobsterKnifeFight.jpg","Parent":{"$ref":"45"}}],"Bio":"Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/band.jpg","RelatedArtists":[]},{"$id":"47","Id":"5eb3eb81-301c-437a-864c-a4ea0103bf79","Name":"The Killers","Albums":[{"$id":"48","Id":"b20c23a8-601b-43a7-8bc8-a4ea0103bf79","Name":"Hot Fuss","ReleaseDate":"2015-08-03T00:00:00","CoverUri":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Album/Killers_HotFuss.jpg","Parent":{"$ref":"47"}}],"Bio":"The Killers are an American rock band formed in Las Vegas, Nevada in 2001, by Brandon Flowers (lead vocals, keyboards) and Dave Keuning (guitar, backing vocals). Mark Stoermer (bass, backing vocals) and Ronnie Vannucci Jr. (drums, percussion) would complete the current line-up of the band in 2002. The name The Killers is derived from a logo on the bass drum of a fictitious band, portrayed in the music video for the New Order song Crystal.","PictureUrl":"http://192.168.100.137/AngularMusicStore.Api/Content/Images/Artist/TheKillers.jpg","RelatedArtists":[]}];

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope.$new();
		$httpBackend = _$httpBackend_;

		controller = $controller('ArtistCtrl', {$scope: scope});
	}));

	it('should have a valid artist controller', function(){
		expect(controller).not.toBeNull();
	});

	it('should have a collection of artists that has been "chunked" for three column display', function(){
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist').respond(queryResponseforAllArtists);

		
		$httpBackend.flush();
		
		expect(scope.threeColumnArtistsList).toBeDefined();

		expect(scope.artistsFound.length).toBe(24);
		expect(scope.threeColumnArtistsList.length).toBe(8);
		expect(scope.threeColumnArtistsList[0].length).toBe(3);
		expect(scope.threeColumnArtistsList[1].length).toBe(3);
		expect(scope.threeColumnArtistsList[2].length).toBe(3);
		expect(scope.threeColumnArtistsList[3].length).toBe(3);
		expect(scope.threeColumnArtistsList[4].length).toBe(3);
		expect(scope.threeColumnArtistsList[5].length).toBe(3);
		expect(scope.threeColumnArtistsList[6].length).toBe(3);
		expect(scope.threeColumnArtistsList[7].length).toBe(3);
	});

	it('should have a list of the top 50 artists when the page loads', function(){
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist').respond(queryResponseforAllArtists);
		
		$httpBackend.flush();
		expect(scope.artistsFound).not.toBeNull();
		expect(scope.artistsFound).toBeDefined();
		var numberOfArtistsFound = scope.artistsFound.length;
		expect(numberOfArtistsFound).toBe(24);
	});

	it('should bring back an array of artsts when searching', function(){
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist').respond(queryResponseforAllArtists);		
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist?name=u').respond(queryResponseForArtistNameU);
		
		scope.artistToSearchFor = 'u';
		scope.searchForArtist();
		$httpBackend.flush();
		
		expect(scope.artistsFound).not.toBeNull();
		expect(scope.artistsFound[0].Name).toBe('Rush');
	})
});