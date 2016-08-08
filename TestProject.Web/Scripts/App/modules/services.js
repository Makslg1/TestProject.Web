'use strict';

angular.module('LinksBuilder')
    .factory("LinksBuilderService", ['$http', '$q', function ($http, $q) {
        return {
            getLinks: function () {
                var deferred = $q.defer();
                $http({ method: 'GET', url: '/api' }).
                 success(function (data, status, headers, config) {
                     deferred.resolve(data);
                 }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            },
            putLink: function (l) {
                var deferred = $q.defer();
                $http({ method: 'PUT', url: '/api', params: { link: l } }).
                 success(function (data, status, headers, config) {
                     deferred.resolve(data);
                 }).
                error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            }
        }
        return service;
    }]);
