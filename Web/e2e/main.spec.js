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
  });

  it('list two options', function () {
    expect(page.thumbnailEls.count()).toBe(2);
  });

});
