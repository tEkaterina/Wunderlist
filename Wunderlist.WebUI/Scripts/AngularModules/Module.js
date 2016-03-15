/// <reference path="UserProfileController.js" />
var app = angular.module("WunderlistModule", []);

app.controller('toDoListCtrl', function ($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;

    $http.get("/ListTasks/GetToDoLists")
        .success(function (result) {
            $scope.toDoList = result;
            var element = document.getElementById("taskScroll");
            element.setAttribute("class", "tasks-scroll hidden");
        })
        .error(function (result) {
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
        if ($scope.nameOperation === "Переименовать список") {
            var listItemId = currentlistId;
            var listname = toDoList.Name;
            $http.post("/ListTasks/RenameToDoList", { listItemId: listItemId, listname: listname })
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
        if ($scope.nameOperation === "Переименовать задачу") {
            var taskItemId = currentlistId;
            var taskname = toDoList.Name;
            var listItem = $scope.namelist;
            $http.post("/ToDoItem/RenameToDoItem", { taskItemId: taskItemId, taskname: taskname, listname: listItem })
                    .success(function (result) {
                        $scope.toDoItems = result;
                        $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function (resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        });
                    })
                    .error(function (result) {
                        console.log(result);
                    });
            $scope.nameOperation = "Создать список";
        }
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
                    $scope.toDoItems = result;
                    $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function (resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        });
                })
                .error(function (result) {
                    console.log(result);
                });
    };

    $scope.addtodoitem = function (todoitem) {
        var listname = $scope.namelist;
        $http.post("/ToDoItem/AddToDoItem", { name: todoitem.Name, listname: listname })
            .success(function (result) {
                $scope.toDoItems = result;
                todoitem.Name = "";
            })
            .error(function (result) {
                console.log(result);
            });
    };

    $scope.deletetoDoItem = function (item) {
        var listname = $scope.namelist;
        var toDoItemId = item.Id;
        $http.put("/ToDoItem/DeleteToDoItem", { taskId: toDoItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoItems = result;
                    $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function (resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        });
                })
                .error(function (result) {
                    console.log(result);
                });
    }

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

    //$scope.renameList = function (listItem) {
    //    $scope.nameOperation = "Переименовать список";
    //    currentlistId = listItem.Id;
    //    window.location.href = '#createTask';
    //    var elem = document.getElementById('listname');
    //    elem.value = listItem.Name;
    //}

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

    $scope.renametoDoItem = function (toDoItem) {
        $scope.nameOperation = "Переименовать задачу";
        rename(toDoItem);
    }

    $scope.toDoTaskCompleted = function (id, status) {
        if (status) {
            $http.post("/ToDoItem/ChangeTaskStatus", { taskId: id, status: status, listId: currentlistId })
            .success(function (result) {
                $scope.toDoItems = result;
                $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function (resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        });
            })
            .error(function (result) {
                console.log(result);
            });
        }
    };


    $scope.getCompletedTasks = function () {
        var element = document.getElementById("completedList");
        var title = element.getAttribute("title");
        if (title === "hidden") {
            element.setAttribute("title", "active");
            element.setAttribute("class", "tasks");
            $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                .success(function (result) {
                    $scope.toDoCompletedItems = result;
                })
                .error(function (result) {
                    console.log(result);
                });
        } else if (title === "active") {
            element.setAttribute("title", "hidden");
            element.setAttribute("class", "tasks hidden");
        }
    };

    $scope.doubleClick = function (e) {
        e.preventDefault();
        $("#wrapper-right").toggleClass("toggled");
    }
});