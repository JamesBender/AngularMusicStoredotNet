'use strict';

angular.module('musicStore').controller('ArtistDetailCtrl', [
	'$scope', 
	'$routeParams', 
	'musicStoreArtistAPI', 
	function ($scope, $routeParams, musicStoreArtistAPI) {

	musicStoreArtistAPI.get({id: $routeParams.id}, function(data){
		$scope.artistName = data.Name;
		$scope.bio = data.Bio;
		$scope.pictureUrl = data.PictureUrl;
		$scope.albums = data.Albums;
	});
}]);