console.log('This would be the main JS file.');

var nameApp = angular.module('TestApp', ['ngRoute']);

nameApp.config(function($routeProvider) {
  $routeProvider.
    when('/', {
      templateUrl: 'locales.html',
      controller: 'LocalesCtrl'
    }).
    when('/:locale', {
      templateUrl: 'localeDetails.html',
      controller: 'LocaleDetailsCtr'
    }).
    otherwise({
      redirectTo: '/'
    });
});

nameApp.controller('LocalesCtrl', function ($scope, $http){
  $http.get('http://localeapi.apphb.com').success(function(data) {
    $scope.translations = data;
  });
});

nameApp.controller('LocaleDetailsCtr', function ($scope, $http, $routeParams){
  $scope.locale = $routeParams.locale;
  $http.get('http://localeapi.apphb.com/').success(function(data) {
      $scope.translations = data;
      var details = data.filter(function(entry){
        return entry.locale === $scope.locale;
      })[0];

      $scope.localeDetails = details;
  });



});
