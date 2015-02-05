if (window.location.protocol == "https:"){
  window.location.href = "http:" + window.location.href.substring(window.location.protocol.length);
}


var nameApp = angular.module('TestApp', ['ngRoute']);



nameApp.config(function($routeProvider, $window) {




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

nameApp.controller('LocaleDetailsCtr', function ($scope, $http, $routeParams, $location, $anchorScroll){

  $scope.locale = $routeParams.locale;
  $http.get('http://localeapi.apphb.com/').success(function(data) {
      $scope.translations = data;
      var details = data.filter(function(entry){
        return entry.locale === $scope.locale;
      })[0];

      $scope.localeDetails = details;
  });
   var old = $location.hash();
    $location.hash('details');
    $anchorScroll();
    //reset to old to keep any additional routing logic from kicking in
    $location.hash(old);




});
