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
      .otherwise({
        redirectTo: '/'
      });
  })
;
