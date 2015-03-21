describe('controllers', function(){
	var scope;

	beforeEach(module('musicStore'));

	beforeEach(inject(function($rootScope){
		scope = $rootScope.$new();
	}));

	it('should have a valid artist controller', inject(function($controller){

		$controller('ArtistCtrl', {
			$scope: scope
		});

//		expect(scope.foo).toBe('bar');
	}))
});