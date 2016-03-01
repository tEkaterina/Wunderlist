app.service("service", function ($http) {

    //Read all Students  
    this.getTasks = function () {

        return $http.get("/ManageTaskApi");
    };
});