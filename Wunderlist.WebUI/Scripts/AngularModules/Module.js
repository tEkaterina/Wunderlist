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
        var listname = item.Name;
        $scope.namelist = listname;
        $scope.toDoItems = "";
        $http.post("/Main/GetToDoItems", { listName: listname })
                .success(function (result) {
                    $scope.toDoItems = result;
                })
                .error(function (result) {
                    console.log(result);
                });
    };

    $scope.addtodoitem = function ( todoitem ) {
        var listname = $scope.namelist;
        //TODO: check on empty string
        $http.post("/Main/AddToDoItem", { name: todoitem.Name, listname: listname })
            .success(function (result) {
                $scope.toDoItems = result;
                todoitem.Name = "";
            })
            .error(function (result) {
                console.log(result);
            });
    };

    $scope.deletetoDoItem = function(item) {
        var listname = $scope.namelist;
        //TODO: check on empty string
        var toDoItemId = item.attributes['id'].value;
        $http.post("/Main/DeleteToDoItem", { taskId: toDoItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoItems = result;
                })
                .error(function (result) {
                    console.log(result);
                });
    }
});