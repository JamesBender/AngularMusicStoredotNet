'use strict';

angular.module('musicStore').controller('EditArtistCtrl', ['$scope', '$routeParams', '$location', 'musicStoreArtistAPI', 
	function($scope, $routeParams, $location, musicStoreArtistAPI){

	$scope.artist = {};
	$scope.artist.name='';
	$scope.artist.bio='';
	$scope.artist.id = $routeParams.id;

	if ($scope.artist.id)
	{
		musicStoreArtistAPI.get({id: $scope.artist.id}, function(data){
			$scope.artist.name = data.Name;
			$scope.artist.bio = data.Bio;
			$scope.artist.pictureUrl = data.PictureUrl;
		});
	}

	$scope.saveArtist = function(){
		var artist = new musicStoreArtistAPI({id: $scope.artist.id, name: $scope.artist.name, bio: $scope.artist.bio, pictureUrl: $scope.artist.pictureUrl});
		artist.$save(function(response){
			if ($routeParams.id)
			{
				$location.path('/artist');
			}
			else
			{
			$location.path('/artist/edit/' + response.Id);
		}
		}, function(err){
			$scope.artist.bio = 'crap: ' + err.status + ' : ' + err.statusText;
		});
	};
}]);