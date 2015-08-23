'use strict';

angular.module('musicStore').controller('ArtistDetailCtrl', [
	'$scope', 
	'$routeParams', 
	'$location',
	'musicStoreArtistAPI', 
	function ($scope, $routeParams, $location, musicStoreArtistAPI) {

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
}]);