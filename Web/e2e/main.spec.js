'use strict';

describe('The main view', function () {
  var page;

  beforeEach(function () {
    browser.get('http://localhost:3000/index.html');
    page = require('./main.po');
  });

  it('should include jumbotron with correct data', function() {
    expect(page.h1El.getText()).toBe('Welcome to the Angular Music Store!');
    expect(page.lead.getText()).toBe('Select either Artists or Albums below!')
    //expect(page.imgEl.getAttribute('src')).toMatch(/assets\/images\/yeoman.png$/);
    //expect(page.imgEl.getAttribute('alt')).toBe('I\'m Yeoman');
  });

  it('list two options', function () {
    expect(page.thumbnailEls.count()).toBe(2);
  });

});
