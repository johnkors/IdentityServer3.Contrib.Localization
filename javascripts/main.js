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
  
  var url =  $location.url();  
  if(!url){    
    
    // get browser language
    $http.get('http://localeapi.apphb.com/language').then(    
      function(res) { 
        $scope.locale = res.data;
        $location.url($scope.locale);        
      }, 
      function(data){      
        $scope.locale = "de-DK";
    });
  }else{    
    
    // use default
    $scope.locale = url.substring(1, url.length);
  }



  $scope.submitted = function(){      
      $location.url($scope.locale);      
  }
});

nameApp.controller('LocaleDetailsCtr', function ($scope, $http, $routeParams, $location, $anchorScroll){
    $scope.locale = $routeParams.locale;
    $scope.given = $scope.locale;
    
    $http.get('http://localeapi.apphb.com/locale/' + $scope.locale).then(    
      function(res) { 
          $scope.fetched = res.data.locale;
          $scope.translations = res.data.translations;
          $scope.headerlanguage = res.data.headerLanguage        
          $scope.localeDetails = res.data;
      }, 
      function(data){        
    });
    
    var old = $location.hash();
    $location.hash('details');
    $anchorScroll();
    //reset to old to keep any additional routing logic from kicking in
    $location.hash(old);
});
