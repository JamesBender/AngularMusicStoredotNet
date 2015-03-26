describe('artstDetailController', function(){
	var scope, $httpBackend, controller;
	
	var artistId = "a82ac00f-5b46-4347-925f-a46400de32be";
	var artistName = "Rush";
	var pictureUrl = "http://localhost:21138/Content/Images/band.jpg";
	var bio = "this is a bio";

	var artist = {
		"Id": artistId,
		"Name": artistName,
		"PictureUrl": pictureUrl,
		"Bio": bio	
	}

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope.$new();
		$httpBackend = _$httpBackend_;
		$httpBackend.expectGET('http://localhost:21138/api/artist/' + artistId).respond(artist);
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
});