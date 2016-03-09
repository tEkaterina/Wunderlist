var app = angular.module("WunderlistModule", []);

app.controller('toDoListCtrl', function($scope, $http) {

    $scope.toDoList = "";
    $http.get("/Main/GetToDoLists")
        .success(function(result) {
            $scope.toDoList = result;
        })
        .error(function(result) {
            console.log(result);
        });

    $scope.savedata = function (toDoList) {
        $http.post("/Main/AddToDoList", { name: toDoList.Name })
            .success(function (result) {
                $scope.toDoList = result;
            })
            .error(function(result) {
                console.log(result);
            });
    }
    $scope.namelist = "";
    $scope.selectList = function (item) {
        $scope.namelist = item.Name;
    };
});

app.Controller('toDoItemCtrl', function($scope, $http) {

    $scope.toDoItems = "";
    $http.post("/Main/GetToDoItems", { name: $scope.namelist })
            .success(function (result) {
                $scope.toDoItems = result;
            })
            .error(function (result) {
                console.log(result);
            });
})