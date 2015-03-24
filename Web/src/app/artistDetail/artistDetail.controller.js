'use strict';

angular.module('musicStore').controller('ArtistDetailCtrl', ['$scope', '$routeParams', 'musicStoreAPI', function ($scope, $routeParams, musicStoreAPI) {

  $scope.artistName = "put stuff here " + $routeParams.id;

}]);