/**
 * This file uses the Page Object pattern to define the main page for tests
 * https://docs.google.com/presentation/d/1B6manhG0zEXkC-H-tPo2vwU06JhL8w9-XCF9oehXzAQ
 */

'use strict';

var MainPage = function() { 
  this.jumbEl = element(by.css('.jumbotron'));
  this.h1El = this.jumbEl.element(by.css('h1'));
  this.lead = this.jumbEl.element(by.css('.lead'));
  this.thumbnailEls = element(by.css('body')).all(by.repeater('category in categories'));
  //this.artistH3 = element(by.css('.row')).element(by.css('h3'));
  //this.artistP = element(by.css('.row')).element(by.css('p'));
};

module.exports = new MainPage();
