app.controller('ToDoListsController', function($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;
    $scope.$on('handleEmit', function(event, args) {
        $rootScope.$broadcast('handleBroadcast', args);
    });

    $http.get("/ListTasks/GetToDoLists")
        .success(function(result) {
            $scope.toDoList = result;
            var element = document.getElementById("taskScroll");
            element.setAttribute("class", "tasks-scroll hidden");
        })
        .error(function(result) {
            console.log(result);
        });

    $scope.savedata = function (toDoList) {
        if ($scope.nameOperation === "Создать список") {
            $http.post("/ListTasks/AddToDoList", { name: toDoList.Name })
                .success(function (result) {
                    $scope.toDoList = result;
                })
                .error(function (result) {
                    console.log(result);
                });
        }
        //if ($scope.nameOperation === "Переименовать список") {
        //    var listItemId = currentlistId;
        //    var listname = toDoList.Name;
        //    $http.post("/ListTasks/RenameToDoList", { listItemId: listItemId, listname: listname })
        //            .success(function (result) {
        //                $scope.toDoList = result;
        //                $scope.toDoItems = "";
        //                $scope.namelist = "";
        //            })
        //            .error(function (result) {
        //                console.log(result);
        //            });
        //    $scope.nameOperation = "Создать список";
        //}
        //if ($scope.nameOperation === "Переименовать задачу") {
        //    var taskItemId = currentlistId;
        //    var taskname = toDoList.Name;
        //    var listItem = $scope.namelist;
        //    $http.post("/ToDoItem/RenameToDoItem", { taskItemId: taskItemId, taskname: taskname, listname: listItem })
        //            .success(function (result) {
        //                $scope.toDoItems = result;
        //                $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
        //                .success(function (resultJson) {
        //                    $scope.toDoCompletedItems = resultJson;
        //                });
        //            })
        //            .error(function (result) {
        //                console.log(result);
        //            });
        //    $scope.nameOperation = "Создать список";
        //}
    }

    $scope.namelist = "";
    $scope.selectList = function (item) {
        var element = document.getElementById("taskScroll");
        element.setAttribute("class", "taskScroll");
        var listname = item.Name;
        currentlistId = item.Id;
        $scope.namelist = listname;
        $scope.toDoItems = "";
        $http.post("/ToDoItem/GetToDoItems", { listName: listname })
                .success(function (result) {

                    $scope.$emit('handleEmit', {message: result});

                    });
                    $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function (resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        })
                .error(function (result) {
                    console.log(result);
                });
    };


    $scope.deleteList = function () {
        var listname = $scope.namelist;
        var listItemId = this.listItem.Id;
        $http.put("/ListTasks/DeleteToDoList", { listItemId: listItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoList = result;
                    $scope.toDoItems = "";
                    $scope.toDoCompletedItems = "";
                    $scope.namelist = "";
                })
                .error(function (result) {
                    console.log(result);
                });
    }

    function rename(list) {
        currentlistId = list.Id;
        window.location.href = '#createTask';
        var elem = document.getElementById('listname');
        elem.value = list.Name;
    }

    $scope.renameList = function (listItem) {
        $scope.nameOperation = "Переименовать список";
        rename(listItem);
    }

});