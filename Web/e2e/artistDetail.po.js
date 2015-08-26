'use strict';

var ArtistDetailPage = function() { 
	this.mainLabel = element(by.css('h1'));
	this.artstToSearchFor = element(by.css('#artistName'));
	this.searchButton = element(by.css('#search'));	
	this.bandImage = element(by.css('#bandImage'));
	this.bandBio = element(by.css('#bandBio'));
	this.listOfAlbums = element.all(by.repeater('album in albums'));
	this.editArtistButton = element(by.css('#editArtist'));
};

module.exports = new ArtistDetailPage();