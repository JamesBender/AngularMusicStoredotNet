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
});