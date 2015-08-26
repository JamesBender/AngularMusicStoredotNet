'use strict';

angular.module('musicStore').controller('AlbumCtrl', 
	['$scope', 'musicStoreAlbumAPI', 'arrayChunkingService', function($scope, musicStoreAlbumAPI, arrayChunkingService){

	var albumsFound = [];

	$scope.searchForAlbum = function(){
		var albumToSearchFor = $scope.albumToSearchFor;

		var results = musicStoreAlbumAPI.query({albumName: albumToSearchFor}, function(data){
			$scope.albumsFound = arrayChunkingService.chunk(data, 3);
		});
	};

	musicStoreAlbumAPI.query(function(data){
		$scope.albumsFound = arrayChunkingService.chunk(data, 2);
	});
}]);