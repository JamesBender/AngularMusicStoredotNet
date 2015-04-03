'use strict';

angular.module('musicStore').controller('ArtistDetailCtrl', ['$scope', '$routeParams', 'musicStoreAPI', function ($scope, $routeParams, musicStoreAPI) {

	musicStoreAPI.get({id: $routeParams.id}, function(data){
		$scope.artistName = data.Name;
		$scope.bio = data.Bio;
		$scope.pictureUrl = data.PictureUrl;
		$scope.albums = data.Albums;
	});
}]);