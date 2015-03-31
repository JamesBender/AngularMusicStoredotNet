'use strict';

describe('The artist view', function () {
  var page;

  beforeEach(function () {
    browser.get('http://localhost:3000/#/artist');
    page = require('./artist.po');
  });

  it('should have the correct label', function() {
    expect(page.mainLabel.getText()).toBe('Search by Artist');
  });

  it('should be able to type a value for artist name and get results back', function(){
    page.artstToSearchFor.sendKeys('u');
    page.searchButton.click().then(function(){
      var artistElement
      expect(element.all(by.repeater('artist in artistsFound')).count()).toBe(1);
      expect(element.all(by.repeater('artist in artistsFound')).then(function(artists){
        var foundArtist = artists[0];
        expect(foundArtist).not.toBeNull();
        var link = foundArtist.element(by.css('a'));
        expect(link).not.toBeNull();
        var artistName = link.getText();
        expect(artistName).toBe('Rush');
        link.click().then(function(){
          expect(element(by.css('h1')).getText()).toBe('Rush');
        });
      }));
    });
  });
});
