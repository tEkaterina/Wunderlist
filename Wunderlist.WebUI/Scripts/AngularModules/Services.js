app.service("service", function ($http) {

    this.getTasks = function () {

        return $http.get("/api/ManageTaskApi");
    };
});