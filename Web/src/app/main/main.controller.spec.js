'use strict';

describe('controllers', function(){
  var scope;

  beforeEach(module('musicStore'));

  beforeEach(inject(function($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should have catoegory for artist and album search', inject(function($controller) {
    expect(scope.categories).toBeUndefined();

    $controller('MainCtrl', {
      $scope: scope
    });

    expect(angular.isArray(scope.categories)).toBeTruthy();
    expect(scope.categories.length === 2).toBeTruthy();
    
    var artist = $.grep(scope.categories, function(e){ return e.title == 'Search By Artist'; })[0];
    
    expect(artist).not.toBe(null);

    var album = $.grep(scope.categories, function(e){ return e.title == 'Search By Album';})[0];

    expect(album).not.toBe(null);
  }));
});
