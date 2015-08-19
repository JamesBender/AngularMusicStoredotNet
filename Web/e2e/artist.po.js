'use strict';

var ArtistPage = function() { 
	this.mainLabel = element(by.css('h1'));
	this.artstToSearchFor = element(by.css('#artistName'));
	this.searchButton = element(by.css('#search'));
	this.addNewArtistButton = element(by.css('#addArtist'));
};

module.exports = new ArtistPage();