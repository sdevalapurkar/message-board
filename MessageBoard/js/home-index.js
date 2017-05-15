(function () {
    "use strict";

    var topicsController = function ($http, dataService) {
        var vm = this;
        vm.name = "Shreyas";
        vm.dataCount = 0;

        vm.data = {
            topics: dataService.topics
        };

        vm.isBusy = false;

        if (dataService.isReady() == false) {

            vm.isBusy = true;

            dataService.getTopics().then(function(response) {

                    //success
                    vm.dataCount = response.length;

//                    vm.data.topics = response;

                },
                function() {
                    //fail

                    alert("could not load topics");

                }).then(function() {
                vm.isBusy = false;
            });

        }
    };

    function newTopicController($http, $window, dataService) {
        var vm = this;

        vm.newTopic = {};

        vm.save = function() {

            dataService.addTopic(vm.newTopic)
                .then(function() {
                        //success
                        $window.location = "#/";
                    },
                    function() {
                        //fail
                        alert("could not save the new topic");
                    });

        };
    }

    function singleTopicController($window, dataService, $routeParams) {

        var vm = this;
        vm.topic = null;
        vm.newReply = {};

        dataService.getTopicById($routeParams.id)
            .then(function(topic) {
                //success
                vm.topic = topic;
            }, function () {
                //fail
                $window.location = "#/";
            });

        vm.addReply = function() {
            dataService.saveReply(vm.topic, vm.newReply)
                .then(function() {
                        //success
                        vm.newReply.body = "";
                    },
                    function() {
                        //fail
                        alert("could not save new reply")
                    });
        };



    }

    app.controller("topicsController", ["$http", "dataService", topicsController]);
    app.controller("newTopicController", ["$http", "$window", "dataService", newTopicController]);
    app.controller("singleTopicController", ["$window", "dataService", "$routeParams", singleTopicController]);
}());
