'use strict';

describe('The artist detail view', function () {
  var page;

  beforeEach(function () {
    browser.get('http://localhost:3000/#/artist');
    page = require('./artistDetail.po');

    page.artstToSearchFor.sendKeys('u');
    page.searchButton.click().then(function(){
      expect(element.all(by.repeater('artist in artistsFound')).then(function(artists){
        var firstArtist = artists[0];
        expect(firstArtist).not.toBeNull();
        var link = firstArtist.element(by.css('a'));
        expect(link).not.toBeNull();
        link.click().then(function(){
          expect(page.mainLabel.getText()).toBe('Rush');
        });
      }));
    });
  });

  it('should have correct main label', function(){
    expect(page.mainLabel.getText()).toBe('Rush');
  });

  it('should have a bio and a picture', function(){
    expect(page.bandImage).not.toBeNull();    
    page.bandImage.getAttribute('src').then(function(imageSrc){
      expect(imageSrc).not.toBeNull();
      expect(imageSrc.indexOf('band.jpg')).toBe(38);    
    });
    expect(page.bandBio).not.toBeNull();
    expect(page.bandBio.getText()).toBe('They are from Canada. They are alright I guess');
  });

  it('should have a list of albums', function(){
    expect(page.listOfAlbums.count()).toBe(1);    
    expect(page.listOfAlbums.then(function(albums){
      expect(albums[0]).not.toBeNull();
      
      var coverImg = albums[0].element(by.css('img'));
      expect(coverImg).not.toBeNull();
      coverImg.getAttribute('src').then(function(imgSrc){
        expect(imgSrc).not.toBeNull();
        expect(imgSrc.indexOf('LobsterKnifeFight.jpg')).toBe(38);

      });

      expect(element(by.css('.albumName')).getText()).toBe('Clockwork Angles');
      expect(element(by.css('.releaseDate')).getText()).toBe('Mar 30, 2013');
    }));
  });
});
