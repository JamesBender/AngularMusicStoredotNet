'use strict';

angular.module('musicStore').controller('AlbumDetailCtrl',['$scope', 
	'$routeParams', 
	'musicStoreAlbumAPI',
	function($scope, $routeParams, musicStoreAlbumAPI){

musicStoreAlbumAPI.get({id: $routeParams.id}, function(data){
		$scope.albumName = data.Name;
		$scope.albumCoverUri = data.CoverUri;	
		// $scope.artistName = data.Name;
		// $scope.bio = data.Bio;
		// $scope.pictureUrl = data.PictureUrl;
		// $scope.albums = data.Albums;
	});
}]);