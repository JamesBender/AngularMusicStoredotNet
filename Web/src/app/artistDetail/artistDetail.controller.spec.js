describe('artstDetailController', function(){
	var scope, $httpBackend, controller;
	
	var artistId = "a82ac00f-5b46-4347-925f-a46400de32be";
	var artistName = "Rush";
	var pictureUrl = "http://localhost:21138/Content/Images/band.jpg";
	var bio = "this is a bio";
	var albumId = "17587050-c7b0-4bad-bc57-a4670131f7d4";
	var albumName = "Clockwork Angles";
	var albumReleaseDate = "2013-03-26T18:33:59";

	var artist = {
		"$id": "1",
		"Id": artistId,
		"Name": artistName,
		"Albums": [
			{
				"$id": "2",
				"Id": albumId,
				"Name": albumName,
				"ReleaseDate": albumReleaseDate,
				"CoverUri": null,
				"Parent": {
					"$ref": "1"
					}
			}
		],
		"Bio": bio,
		"PictureUrl": pictureUrl,
		"RelatedArtists": []
	};

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope.$new();
		$httpBackend = _$httpBackend_;

		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist/' + artistId).respond(artist);
		controller = $controller('ArtistDetailCtrl', {$scope: scope, $routeParams: {id: artistId}});
	}));

	it('should have a valid artist detail controller', function(){
		expect(controller).not.toBeNull();
	});

	it('should be able to get artist detail and assign to scope', function(){
		$httpBackend.flush();
		expect(scope.artistName).toBe(artistName);
		expect(scope.bio).toBe(bio);
		expect(scope.pictureUrl).toBe(pictureUrl);
	});

	it('should be able to get album details for artist', function(){
		$httpBackend.flush();
		var albums = scope.albums;
		expect(albums).not.toBeNull();
		expect(albums.length).toBe(1);
		expect(albums[0]).not.toBeNull();
		var album = albums[0];
		expect(album.Id).toBe(albumId);
		expect(album.Name).toBe(albumName);
		expect(album.ReleaseDate).toBe(albumReleaseDate);
	});
});