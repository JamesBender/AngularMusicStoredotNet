describe('The edit artist view', function(){
	var scope, $httpBackend, controller;

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope;
		$httpBackend = _$httpBackend_;
		controller = $controller;

		controller = $controller('EditArtistCtrl', {$scope: scope});
	}));

	it('should get a valid edit artist controller', function(){
		expect(controller).toBeDefined();	
	});

	it('should have an empty artist name and bio when creating a new artist', function(){
		expect(scope).toBeDefined();
		expect(scope.artist.name).toBe('');
		expect(scope.artist.bio).toBe('');
	});

	it('should be able to save a new artist and get an id back', function(){
		expect($httpBackend).toBeDefined();
		expect($httpBackend.expectPOST).toBeDefined();
		$httpBackend.expectPOST('http://192.168.100.137/AngularMusicStore.Api/api/artist', '{"name":"test name","bio":"test bio"}')
			.respond(201, '{"Id":"12345"}');
		scope.artist.name = 'test name';
		scope.artist.bio = 'test bio';

		scope.saveArtist();

		$httpBackend.flush();
		expect(scope.artist.id).toBe('12345');
	});
});