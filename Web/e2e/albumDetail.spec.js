'use strict';

describe('The album detail view', function () {
	var page;

	beforeEach(function () {
		browser.get('http://localhost:3000/#/album');
		page = require('./albumDetail.po');

		page.albumToSearchFor.sendKeys('Clock');
		page.searchButton.click().then(function(){
			expect(element.all(by.repeater('album in albumGroup')).count()).toBe(1);

			expect(element.all(by.repeater('album in albumGroup')).then(function(album){
				var firstAlbum = album[0];
				expect(firstAlbum).toBeDefined();


				var link = firstAlbum.element(by.css('a'));
				expect(link).not.toBeNull();
				link.click().then(function(){
					//expect(page.mainLabel.getText()).toBe('Clockwork Angles');
				});
			}));
		});
	});

	it('shold have the right label and image on the page', function(){
		expect(page.mainLabel.getText()).toBe('Clockwork Angles');
		expect(page.coverImage).toBeDefined();
		page.coverImage.getAttribute('src').then(function(imageSrc){
			expect(imageSrc).not.toBeNull();
			expect(imageSrc.indexOf('Clockwork') > -1).toBeTruthy();    
		});
	});
});
