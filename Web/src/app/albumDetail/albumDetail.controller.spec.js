describe('album detail controller', function(){
	var scope, $httpBackend, controller;

	var albumId = "a82ac00f-5b46-4347-925f-a46400de32be";
	var album = {};

	beforeEach(module('musicStore'));

	beforeEach(inject(function(_$httpBackend_, $rootScope, $controller){
		scope = $rootScope.$new();
		$httpBackend = _$httpBackend_;

		$httpBackend.expectGET('http://192.168.100.137/AngularMusicStore.Api/api/album/' + albumId).respond(album);
		controller = $controller('AlbumDetailCtrl', {$scope: scope, $routeParams: {id: albumId}});
	}));

	it('should have a valid album detail controller', function(){
		expect(controller).toBeDefined();
	});
});