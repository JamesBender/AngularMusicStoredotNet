angular.module('musicStore').directive('amsTrack', function () {
	return {
		restrict: 'E',
		scope: {
			trackInfo: '=track'
		},
		templateUrl: 'components/directives/amsTrack.html'
	};
});