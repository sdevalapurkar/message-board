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

    $routeProvider.when("/message/:id",
        {
            controller:"singleTopicController as vm",
            templateUrl:"/templates/singleTopicView.html"
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

    function _findTopic(id) {

        var found = null;

        $.each(_topics, function(i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }
        });

        return found;

    }

    var _getTopicById = function(id) {
        var deferred = $q.defer();

        if (_isReady()) {

            var topic = _findTopic(id);

            if (topic) {
                deferred.resolve(topic);
            } else {
                deferred.reject();
            }

        } else {
            _getTopics()
                .then(function() {
                        //success
                    var topic = _findTopic(id);

                        if (topic) {
                            deferred.resolve(topic);
                        } else {
                            deferred.reject();
                        }
                    },
                    function() {
                        //fail
                        deferred.reject();
                    });
        }

        return deferred.promise;
    };

    var _saveReply = function(topic, newReply) {

        var deferred = $q.defer();

        $http.post("/api/topics/" + topic.id + "/replies", newReply)
            .then(function(response) {
                //success
                if (topic.replies == null) {
                    topic.replies = [];
                }

                topic.replies.push(response.data);
                deferred.resolve(response.data);

            }, function() {
                //fail
                deferred.reject();
            });

    }

    return {
        topics: _topics,
        isReady: _isReady,
        getTopics: _getTopics,
        addTopic: _addTopic,
        getTopicById: _getTopicById,
        saveReply: _saveReply
};
    });