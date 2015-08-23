'use strict';

angular.module('musicStore').controller('ArtistCtrl', 
	['$scope', 'musicStoreArtistAPI', 'arrayChunkingService', '$location', function ($scope, musicStoreArtistAPI, arrayChunkingService, $location) {

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

	$scope.editArtist = function(){
		// var current = $location.path();
		// $location.path(current + '/edit')
		$location.path('/artist/new')
	};
}]);