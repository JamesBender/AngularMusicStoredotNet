'use strict';

angular.module('musicStore').factory('musicStoreAPI', ['$resource', function($resource){
	var baseUrl = 'http://localhost:21138/api/artist'
	return $resource(baseUrl + '/:id');
}]);