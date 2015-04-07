'use strict';

angular.module('musicStore').factory('musicStoreArtistAPI', ['$resource', function($resource){
	var baseUrl = 'http://localhost:21138/api/artist/:id'
	return $resource(baseUrl);
}]);