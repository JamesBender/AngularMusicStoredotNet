'use strict';

angular.module('musicStore').factory('musicStoreArtistAPI', ['$resource', function($resource){
	var baseUrl = 'http://192.168.100.137/AngularMusicStore.Api/api/artist/:id'
	return $resource(baseUrl);
}]);