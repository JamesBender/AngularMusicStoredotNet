describe('chunking service', function(){
	
	beforeEach(module('musicStore'));

	var testArrayService;

	beforeEach(inject(function(arrayChunkingService) {
                testArrayService = arrayChunkingService;
        }));

	it('should not be null', function(){
		expect(testArrayService).not.toBeNull();
	});

	it('should be able to chunk an array to three columns', function(){
		var rawArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		var result = testArrayService.chunk(rawArray, 3);

		expect(result).toBeDefined();
		expect(result.length).toBe(3);
		expect(result[0].length).toBe(3);
		expect(result[1].length).toBe(3);
		expect(result[2].length).toBe(3);
	});

	it('should be able to handle uneven arrays', function(){
		var rawArray = [1, 2, 3, 4, 5, 6, 7, 8];
		var result = testArrayService.chunk(rawArray, 3);

		expect(result).toBeDefined();
		expect(result.length).toBe(3);
		expect(result[0].length).toBe(3);
		expect(result[1].length).toBe(3);
		expect(result[2].length).toBe(2);
	});
});