describe('controllers', function(){
	var scope, $httpBackend, controller;
	var queryResponseForArtistNameU = [{"$id":"1","Id":"a82ac00f-5b46-4347-925f-a46400de32be","Name":"Rush","Albums":[{"$id":"2","Id":"e8aeeb75-8d41-4340-a7a6-a46400de32d0","Name":"Clockwork Angles","ReleaseDate":"2013-03-23T13:28:59","CoverUri":null,"Parent":{"$ref":"1"}}]}];

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope.$new();
		$httpBackend = _$httpBackend_;

		controller = $controller('ArtistCtrl', {$scope: scope});
	}));

	it('should have a valid artist controller', function(){
		expect(controller).not.toBeNull();
	});

	it('should have a list of the top 50 artists when the page loads', function(){
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist').respond(queryResponseForArtistNameU);
		
		$httpBackend.flush();
		expect(scope.artistsFound).not.toBeNull();
		expect(scope.artistsFound).toBeDefined();
		var numberOfArtistsFound = scope.artistsFound.length;
		expect(numberOfArtistsFound).toBeLessThan(51);
		expect(numberOfArtistsFound).toBeGreaterThan(0);
	});

	it('should bring back an array of artsts when searching', function(){
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist').respond(queryResponseForArtistNameU);
		
		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/artist?name=u').respond(queryResponseForArtistNameU);
		
		scope.artistToSearchFor = 'u';
		scope.searchForArtist();
		$httpBackend.flush();
		
		expect(scope.artistsFound).not.toBeNull();
		expect(scope.artistsFound[0].Name).toBe('Rush');
	})
});