'use strict';

angular.module('musicStore')
  .controller('MainCtrl', function ($scope) {
    $scope.categories = [
      {
        'title': 'Search By Artist',
        'url': '#/artist',
        'description': 'Search for music by artist name.',
        'logo': 'guitar20.png'
      },
      {
        'title': 'Search By Album',
        'url': 'http://browsersync.io/',
        'description': 'Search for a specific album.',
        'logo': 'piano15.png'
      }
    ];
  });