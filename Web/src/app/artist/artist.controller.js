'use strict';

angular.module('musicStore').controller('ArtistCtrl', 
	['$scope', 'musicStoreArtistAPI', 'arrayChunkingService', function ($scope, musicStoreArtistAPI, arrayChunkingService) {

	$scope.artistsFound = [];
	
	$scope.searchForArtist = function(){
		var artist = $scope.artistToSearchFor;
		var results = musicStoreArtistAPI.query({name: artist}, function(data){
			$scope.artistsFound = arrayChunkingService.chunk(data, 3);
		});
	};

	musicStoreArtistAPI.query(function(data){
		$scope.artistsFound = arrayChunkingService.chunk(data, 3);
	});
}]);