//app.js file

"use strict";

var app = angular.module("app", ["ngRoute"]);

app.config(function($routeProvider) {
    $routeProvider.when("/",
        {
            controller: "topicsController as vm",
            templateUrl: "/templates/topicsView.html"
        });

    $routeProvider.when("/newmessage",
        {
            controller: "newTopicController as vm",
            templateUrl: "/templates/newTopicView.html"
        });

    $routeProvider.otherwise({redirectTo: "/" });
});

app.factory("dataService", function($http, $q) {

        var _topics = [];

        var _isInit = false;

        var _isReady = function() {
            return _isInit;
        }

        var _getTopics = function() {

            var deferred = $q.defer();

            $http.get("/api/topics?includeReplies=true").then(function(response) {
                //success
                angular.copy(response.data, _topics);

                    _isInit = true;

                    deferred.resolve(_topics);
                },
                function() {
                    //error
                    deferred.reject();
                });

            return deferred.promise;

        };

    var _addTopic = function(newTopic) {
        var deferred = $q.defer();

        $http.post("/api/topics", newTopic).then(function successCallBack(response) {
                //successful
                var newlyCreatedTopic = response.data;

                _topics.splice(0, 0, newlyCreatedTopic);

                deferred.resolve(newlyCreatedTopic);

            },
            function errorCallBack(response) {
                //fail
                deferred.reject();
            });

        return deferred.promise;
    };

        return {
            topics: _topics,
            isReady: _isReady,
            getTopics: _getTopics,
            addTopic: _addTopic
    };
    });