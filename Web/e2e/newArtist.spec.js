'use strict';

describe('The edit artist view to create a new artist', function () {
	var page;

	beforeEach(function () {
		browser.get('http://localhost:3000/#/artist/new');
		page = require('./newArtist.po');
	});

	it('should show correct labled correctly and have empty artist name and bio values when you initially navigate to the page', function(){
		expect(page.newArtistLabel).toBeDefined();
		expect(page.newArtistLabel.getText()).toBe('New Artist');
		expect(page.newArtistLabel.isDisplayed()).toBeTruthy();
		expect(page.editArtistLabel.isDisplayed()).toBeFalsy();
		expect(page.artistName.getText()).toBe('');
		expect(page.artistBio.getText()).toBe('');
	});

	it('should be able to create an artist', function(){
		page.artistName.sendKeys('test');
		page.artistBio.sendKeys('bio stuff');
		//browser.pause();

		page.saveButton.click().then(function(){
			//expect(page.artistName.getText()).toBe('not test');
			//expect(page.artistBio.getText()).toBe('something...');
		});
	});
});