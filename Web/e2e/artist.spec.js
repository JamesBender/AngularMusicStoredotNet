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
          expect(attr[0]).toBe('http://localhost:3000/#/artist/aa0f9ee4-009e-4e55-85e3-a4ea0103bf05');
        });
      });
    });
  });
});
