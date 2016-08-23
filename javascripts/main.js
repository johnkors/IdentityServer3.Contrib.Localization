if (window.location.protocol == "https:"){
  window.location.href = "http:" + window.location.href.substring(window.location.protocol.length);
}


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

nameApp.controller('LocalesCtrl', function ($scope, $http, $location, $window){
  
  $http.get('http://localhost:7799/language').then(    
    function(res) { 
      $scope.locale = res.data;
      $location.url($scope.locale);
    }, 
    function(data){ 
      console.log("fuck! Falling back to swearing in danish.");
      $scope.locale = "de-DK";
  });
  
  $scope.submitted = function(){
      console.log("submitted!");
      $location.url($scope.locale);
  }
});

nameApp.controller('LocaleDetailsCtr', function ($scope, $http, $routeParams, $location, $anchorScroll){

    $scope.given = $scope.locale;

    $http.get('http://localhost:7799/locale/' + $scope.locale).then(    
      function(res) { 
          $scope.fetched = res.data.locale;       
          console.log(res);
          $scope.translations = res.data.translations;
          $scope.headerlanguage = res.data.headerLanguage        
          $scope.localeDetails = res.data;
      }, 
      function(data){ 
        console.log("fuck!")
    });
    
    var old = $location.hash();
    $location.hash('details');
    $anchorScroll();
    //reset to old to keep any additional routing logic from kicking in
    $location.hash(old);
});
