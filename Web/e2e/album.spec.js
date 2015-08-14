'use strict';

describe('The album view', function(){
	var page;

	beforeEach(function(){
		browser.get('http://localhost:3000/#/album');
		page = require('./album.po');
	});

	it('should have the correct page label', function(){
		expect(page.mainLabel.getText()).toBe('Search by Album');
	});

	it('should be populated with the first (up to) 50 albums', function(){
		expect(page.listOfAlbumGroups).toBeDefined();
		var albumListCount = page.listOfAlbumGroups.count();
		expect(albumListCount).toBeGreaterThan(0);
		expect(albumListCount).toBeLessThan(51);
	});

	it('should be able to search for an album', function(){
		page.artistToSearchFor.sendKeys('Clock');
		page.searchButton.click().then(function(){
			expect(element.all(by.repeater('albumGroup in albumsFound')).count()).toBe(1);
			expect(element.all(by.repeater('album in albumGroup')).count()).toBe(1);

			var resultList = $$('.albumList tr');

			expect(resultList).toBeDefined();
			expect(resultList).not.toBeNull();
			expect(resultList.count()).toBe(1);


			resultList.each(function(row){
				var dataCell = row.$$('td');
				expect(dataCell.count()).toBe(1);
				expect(dataCell.get(0).getText()).toBe('Clockwork Angles');
				var link = dataCell.$$('a');
				link.getAttribute('href').then(function(attr){
					expect(typeof attr[0]).toBe('string');
					var baseUri = attr[0].substring(0, 30);
					expect(baseUri).toBe('http://localhost:3000/#/album/'); //f3569115-28f5-4a37-a7be-a4f000abd8a2');
				});
			});
		});
	});
});