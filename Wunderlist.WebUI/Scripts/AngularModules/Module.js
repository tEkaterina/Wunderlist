var app = angular.module("WunderlistModule", []);

app.controller('toDoListCtrl', function ($scope, $http) {

    $scope.toDoList = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;

    $http.get("/Main/GetToDoLists")
        .success(function (result) {
            $scope.toDoList = result;
        })
        .error(function (result) {
            console.log(result);
        });


    $scope.savedata = function (toDoList) {
        if ($scope.nameOperation === "Создать список") {
            $http.post("/Main/AddToDoList", { name: toDoList.Name })
                .success(function (result) {
                    $scope.toDoList = result;
                })
                .error(function (result) {
                    console.log(result);
                });
        } else {
            var listItemId = currentlistId;
            var listname = toDoList.Name;
            $http.post("/Main/RenameToDoList", { listItemId: listItemId, listname: listname })
                    .success(function (result) {
                        $scope.toDoList = result;
                        $scope.toDoItems = "";
                        $scope.namelist = "";
                    })
                    .error(function (result) {
                        console.log(result);
                    });
            $scope.nameOperation = "Создать список";
        }
    }

    $scope.namelist = "";
    $scope.selectList = function (item) {
        var listname = item.Name;
        currentlistId = item.Id;
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

    $scope.addtodoitem = function (todoitem) {
        var listname = $scope.namelist;
        $http.post("/Main/AddToDoItem", { name: todoitem.Name, listname: listname })
            .success(function (result) {
                $scope.toDoItems = result;
                todoitem.Name = "";
            })
            .error(function (result) {
                console.log(result);
            });
    };

    $scope.deletetoDoItem = function () {
        var listname = $scope.namelist;
        var toDoItemId = this.toDoItem.Id;
        $http.put("/Main/DeleteToDoItem", { taskId: toDoItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoItems = result;
                })
                .error(function (result) {
                    console.log(result);
                });
    }

    $scope.deleteList = function () {
        var listname = $scope.namelist;
        var listItemId = this.listItem.Id;
        $http.put("/Main/DeleteToDoList", { listItemId: listItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoList = result;
                    $scope.toDoItems = "";
                    $scope.namelist = "";
                })
                .error(function (result) {
                    console.log(result);
                });
    }

    $scope.renameList = function (listItem) {
        $scope.nameOperation = "Переименовать список";
        currentlistId = listItem.Id;
        window.location.href = '#createTask';
        var elem = document.getElementById('listname');
        elem.value = listItem.Name;
    }
});