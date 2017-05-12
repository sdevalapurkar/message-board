(function () {
    "use strict";

    var homeIndexController = function ($http) {
        var vm = this;
        vm.name = "Shreyas";
        vm.dataCount = 0;

        vm.data = [
            
        ];

        $http.get("/api/topics?includeReplies=true")
            .then(function() {
                    //success
                    angular.copy(result.data, vm.data);
                },
                function() {
                    //fail
                    alert("could not load the topics");
                });


    };

app.controller("homeIndexController", [homeIndexController]);
}());