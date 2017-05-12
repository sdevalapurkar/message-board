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

    app.controller("topicsController", ["$http", "dataService", topicsController]);
    app.controller("newTopicController", ["$http", "$window", "dataService", newTopicController]);
}());
