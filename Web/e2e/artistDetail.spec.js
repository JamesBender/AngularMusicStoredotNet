'use strict';

describe('The artist detail view', function () {
  var page;

  beforeEach(function () {
    browser.get('http://localhost:3000/#/artist');
    page = require('./artistDetail.po');

    page.artstToSearchFor.sendKeys('Rush');
    page.searchButton.click().then(function(){
      expect(element.all(by.repeater('artist in artistGroup')).count()).toBe(1);

      expect(element.all(by.repeater('artist in artistGroup')).then(function(artists){
        var firstArtist = artists[0];
        expect(firstArtist).toBeDefined();


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
      expect(imageSrc.indexOf('Rush.jpg') > -1).toBeTruthy();    
    });
    expect(page.bandBio).not.toBeNull();
    expect(page.bandBio.getText()).toBe("Rush is a Canadian rock band formed in August 1968 in the Willowdale neighbourhood of Toronto, Ontario. The band is composed of bassist, keyboardist, and lead vocalist Geddy Lee; guitarist and backing vocalist Alex Lifeson; and drummer, percussionist, and lyricist Neil Peart. The band and its membership went through several reconfigurations between 1968 and 1974, achieving its current form when Peart replaced original drummer John Rutsey in July 1974, two weeks before the group's first United States tour.");
  });

  it('should have a list of albums', function(){
    expect(page.listOfAlbums.count()).toBe(1);    
    expect(page.listOfAlbums.then(function(albums){
      expect(albums[0]).not.toBeNull();
      
      var coverImg = albums[0].element(by.css('img'));
      expect(coverImg).not.toBeNull();
      coverImg.getAttribute('src').then(function(imgSrc){
        expect(imgSrc).not.toBeNull();
        expect(imgSrc.indexOf('Rush_ClockworkAngles.png') > -1).toBeTruthy();

      });

      expect(element(by.css('.albumName')).getText()).toBe('Clockwork Angles');
      expect(element(by.css('.releaseDate')).getText()).toBe('Jun 8, 2012');
    }));
  });

   it('should go to an populated edit artist page when the edit artist button is clicked', function(){
    page.editArtistButton.click().then(function(){
      browser.getCurrentUrl().then(function(actualUrl){
        expect(actualUrl).toContain('/artist/edit');
      });
    });
  });
});
