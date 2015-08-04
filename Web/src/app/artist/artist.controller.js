'use strict';

angular.module('musicStore').controller('ArtistCtrl', ['$scope', 'musicStoreArtistAPI', function ($scope, musicStoreArtistAPI) {

	$scope.artistsFound = [];

	$scope.searchForArtist = function(){
		var artist = $scope.artistToSearchFor;
		var results = musicStoreArtistAPI.query({name: artist}, function(data){
			$scope.artistsFound = data;
		});
	};

	musicStoreArtistAPI.query(function(data){
		$scope.artistsFound = data;
	});
}]);