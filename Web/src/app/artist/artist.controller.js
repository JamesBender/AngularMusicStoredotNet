'use strict';

angular.module('musicStore').controller('ArtistCtrl', ['$scope', 'musicStoreAPI', function ($scope, musicStoreAPI) {

    $scope.searchForArtist = function(){
      var artist = $scope.artistToSearchFor;
      window.alert(artist);
      var results = musicStoreAPI.get({}, function(data){
        window.alert('done');
        $scope.result = 'blah';
      });
    };

  }]);