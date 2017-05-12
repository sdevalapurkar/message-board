(function () {
    "use strict";

    var topicsController = function ($http) {
        var vm = this;
        vm.name = "Shreyas";
        vm.dataCount = 0;

        vm.data = [
            
        ];

        vm.isBusy = true;

        $http({
            method: "GET",
            url: "/api/topics?includeReplies=true"
            }).then(function successCallBack(response) {
                    //success
                angular.copy(response.data, vm.data);
                vm.dataCount = response.data.length;
            },
                function errorCallBack(response) {
                    //fail
                    alert("could not load the topics");
                }).then(function() {
            vm.isBusy = false;
        });


    };

    function newTopicController($http, $window) {
        var vm = this;

        vm.newTopic = {};

        vm.save = function() {

            $http.post("/api/topics", vm.newTopic).then(function successCallBack(response) {
                //successful
                //vm.newTopic = response.data;
                angular.copy(response.data, vm.newTopic);

                    //console.log(vm.newTopic);

                    $window.location = "#/";
                },
                function errorCallBack(response) {
                    //fail
                    alert("could not save new topic");
                });

        };
    }

    app.controller("topicsController", ["$http", topicsController]);
    app.controller("newTopicController", ["$http", "$window", newTopicController]);
}());
