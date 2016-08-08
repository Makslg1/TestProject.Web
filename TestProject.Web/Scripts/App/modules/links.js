'use strict';

angular.module('links')
  .controller('FormController', ['$scope', 'LinksBuilderService', function ($scope, service) {
   
      $scope.submit = function () {
          if ($scope.link) {
              service.putLink($scope.link).then(function () {
                  $scope.link = '';
                  $scope.urlForm.$setPristine();
                  $scope.showMessage = true;              
              });
          }
      };
  }])
    .controller('LinksListController', ['$scope', 'LinksBuilderService', function ($scope, service) {      
        $scope.links = [];
        service.getLinks().then(function (data) {
            $scope.links = data;
        });

    }]);

