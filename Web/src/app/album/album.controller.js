'use strict';

angular.module('musicStore').controller('AlbumCtrl', ['$scope', 'musicStoreAlbumAPI', function($scope, musicStoreAlbumAPI){

	var albumList = [];

	musicStoreAlbumAPI.query(function(data){
		$scope.albumList = data;
	});
}]);