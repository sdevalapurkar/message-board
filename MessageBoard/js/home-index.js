(function () {
    "use strict";

    var homeIndexController = function ($http) {
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
                },
                function errorCallBack(response) {
                    //fail
                    alert("could not load the topics");
                }).then(function() {
            vm.isBusy = false;
        });


    };

app.controller("homeIndexController", ["$http", homeIndexController]);
}());