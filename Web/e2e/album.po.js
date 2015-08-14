'use strict';

var AlbumPage = function() { 
	this.mainLabel = element(by.css('h1'));
	this.artistToSearchFor = element(by.css('#albumName'));
	this.searchButton = element(by.css('#search'));
	this.listOfAlbumGroups = element.all(by.repeater('albumGroup in albumsFound'));
	
};

module.exports = new AlbumPage();