console.log('This would be the main JS file.');

var nameApp = angular.module('TestApp', []);

nameApp.controller('LocaleCtrl', function ($scope, $http){
  $http.get('http://localeapi.apphb.com').success(function(data) {
    $scope.translations = data;
  });
});
