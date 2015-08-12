'use strict';

angular.module('musicStore').factory('musicStoreAlbumAPI', ['$resource', function($resource){
	var baseUrl = 'http://192.168.100.137/AngularMusicStore.Api/api/album/:id'
	return $resource(baseUrl);
}]);