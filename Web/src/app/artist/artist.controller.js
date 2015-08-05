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
		$scope.threeColumnArtistsList = chunk($scope.artistsFound, 3);
	});

	function chunk(arr, size) {
		var newArr = [];
		for (var i=0; i<arr.length; i+=size) {
			newArr.push(arr.slice(i, i+size));
		}
		return newArr;
	}
}]);