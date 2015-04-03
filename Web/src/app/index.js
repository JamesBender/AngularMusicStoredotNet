'use strict';

angular.module('musicStore', ['ngAnimate', 'ngCookies', 'ngTouch', 'ngSanitize', 'ngResource', 'ngRoute', 'ui.bootstrap'])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'app/main/main.html',
        controller: 'MainCtrl'
      })
      .when('/artist', {
        templateUrl: 'app/artist/artist.html',
        controller: 'ArtistCtrl'
      })
      .when('/album', {
        templateUrl: 'app/album/album.html',
        controller: 'AlbumCtrl'
      })
      .when('/artist/:id', {
        templateUrl: 'app/artistDetail/artistDetail.html',
        controller: 'ArtistDetailCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  })
;
