'use strict';

angular.module('musicStore').controller('ArtistDetailCtrl', [
	'$scope', 
	'$routeParams', 
	'$location',
	'$modal',
	'musicStoreArtistAPI', 
	function ($scope, $routeParams, $location, $modal, musicStoreArtistAPI) {

	musicStoreArtistAPI.get({id: $routeParams.id}, function(data){
		$scope.id = data.Id;
		$scope.artistName = data.Name;
		$scope.bio = data.Bio;
		$scope.pictureUrl = data.PictureUrl;
		$scope.albums = data.Albums;
	});

	$scope.editArtist = function(){
		$location.path('/artist/edit/' + $scope.id);
	};

	$scope.deleteArtist = function(){
		var modalInstance = $modal.open({
			animation: true,
			templateUrl: 'confirmArtistDelete.html',
			controller: 'ArtistDeleteCtrl'
		});

		modalInstance.result.then(function(outcome){
			$scope.status = outcome;
		});
	};



	$scope.itWorked = function(){
		$scope.status = 'modal worked';
	};
}]);

angular.module('musicStore').controller('ArtistDeleteCtrl', ['$scope', '$modalInstance', function($scope, $modalInstance){

	$scope.ok = function(){
		$modalInstance.close(true);
	};

	$scope.cancel = function(){
		$modalInstance.close(false);
	};
}]);