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