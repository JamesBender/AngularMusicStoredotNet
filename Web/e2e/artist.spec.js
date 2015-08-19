'use strict';

//var util = require('util');

describe('The artist view', function () {
  var page;

  //var ptor = protractor.getInstance();

  beforeEach(function () {
    browser.get('http://localhost:3000/#/artist');
    page = require('./artist.po');
  });

  it('should have defined page elements', function(){
    expect(page.addNewArtistButton).toBeDefined();
  });

  it('should have the correct label', function() {
    expect(page.mainLabel.getText()).toBe('Search by Artist');
  });

  it('should be able to type a value for artist name and get results back', function(){
    page.artstToSearchFor.sendKeys('Rush');
    page.searchButton.click().then(function(){
      var artistElement
      //expect(element.all(by.repeater('artist in artistsFound')).count()).toBe(5);
      expect(element.all(by.repeater('artistGroup in artistsFound')).count()).toBe(1);
      expect(element.all(by.repeater('artist in artistGroup')).count()).toBe(1);

      var resultList = $$('.artistList tr');

      expect(resultList).toBeDefined();
      expect(resultList).not.toBeNull();
      expect(resultList.count()).toBe(1);

      resultList.each(function(row){
        var dataCell = row.$$('td');
        expect(dataCell.count()).toBe(1);
        expect(dataCell.get(0).getText()).toBe('Rush');
        var link = dataCell.$$('a');
        link.getAttribute('href').then(function(attr){
          expect(typeof attr[0]).toBe('string');
          var baseUri = attr[0].substring(0, 31);
          expect(baseUri).toBe('http://localhost:3000/#/artist/');  //2e41f95a-22d5-4b38-a558-a4f000abd899');
        });
      });
    });
  });

  it('should go to an empty edit artist page when the new artist button is clicked', function(){
    //expect(ptor).toBeDefined();
    page.addNewArtistButton.click().then(function(){
      browser.getCurrentUrl().then(function(actualUrl){
        expect(actualUrl).toContain('/artist/edit');
      });
    });
  });
});
