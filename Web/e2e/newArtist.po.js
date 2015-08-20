'use strict';

var EditArtistPage = function() {
	this.newArtistLabel = element(by.id('newArtistBanner'));
	this.editArtistLabel = element(by.id('editArtistBanner'));
	this.artistName = element(by.id('artistName'));
	this.artistBio = element(by.id('artistBio'));
};

module.exports = new EditArtistPage();