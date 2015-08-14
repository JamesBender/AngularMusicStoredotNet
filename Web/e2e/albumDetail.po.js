'use strict';

var AlbumDetailPage = function() { 
	this.mainLabel = element(by.css('h1'));
	this.albumToSearchFor = element(by.css('#albumName'));
	this.searchButton = element(by.css('#search'));	
	this.coverImage = element(by.css('#albumCover'));
	// this.bandBio = element(by.css('#bandBio'));
	// this.listOfAlbums = element.all(by.repeater('album in albums'));
};

module.exports = new AlbumDetailPage();