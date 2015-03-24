'use strict';

angular.module('musicStore').controller('ArtistCtrl', ['$scope', 'musicStoreAPI', function ($scope, musicStoreAPI) {

  $scope.searchForArtist = function(){
    var artist = $scope.artistToSearchFor;
    var results = musicStoreAPI.query({name: artist}, function(data){
      $scope.artistsFound = data;
    });
  };
}]);