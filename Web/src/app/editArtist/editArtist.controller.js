'use strict';

angular.module('musicStore').controller('EditArtistCtrl', ['$scope', 'musicStoreArtistAPI', function($scope, musicStoreArtistAPI){
	$scope.artist = {};
	$scope.artist.name='';
	$scope.artist.bio='';
	$scope.artist.id='';

	$scope.saveArtist = function(){
		var artist = new musicStoreArtistAPI({name: $scope.artist.name, bio: $scope.artist.bio});
		artist.$save(function(response){
			$scope.artist.id = response.Id;
			//it worked, so, do... something...
		}, function(err){
			//This is just for now, I'll figure out how to handle this later
			$scope.artist.bio = 'crap: ' + err.status + ' : ' + err.statusText;
		});
	};
}]);