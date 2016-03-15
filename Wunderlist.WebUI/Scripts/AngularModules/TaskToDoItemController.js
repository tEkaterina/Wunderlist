app.controller('TaskToDoItemController', function($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;

    $scope.$on('handleBroadcast', function (event, args) {
         $scope.toDoItems = args.message;
    });

    $scope.addtodoitem = function(todoitem) {
        var listname = $scope.namelist;
        $http.post("/ToDoItem/AddToDoItem", { name: todoitem.Name, listname: listname })
            .success(function(result) {
                $scope.toDoItems = result;
                todoitem.Name = "";
            })
            .error(function(result) {
                console.log(result);
            });
    };
    $scope.deletetoDoItem = function(item) {
        var listname = $scope.namelist;
        var toDoItemId = item.Id;
        $http.put("/ToDoItem/DeleteToDoItem", { taskId: toDoItemId, listname: listname })
            .success(function(result) {
                $scope.toDoItems = result;
                $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                    .success(function(resultJson) {
                        $scope.toDoCompletedItems = resultJson;
                    });
            })
            .error(function(result) {
                console.log(result);
            });
    }

    function rename(list) {
        currentlistId = list.Id;
        window.location.href = '#createTask';
        var elem = document.getElementById('listname');
        elem.value = list.Name;
    }

    //$scope.renameList = function (listItem) {
    //    $scope.nameOperation = "Переименовать список";
    //    rename(listItem);
    //}

    $scope.renametoDoItem = function(toDoItem) {
        $scope.nameOperation = "Переименовать задачу";
        rename(toDoItem);
    }

    $scope.toDoTaskCompleted = function(id, status) {
        if (status) {
            $http.post("/ToDoItem/ChangeTaskStatus", { taskId: id, status: status, listId: currentlistId })
                .success(function(result) {
                    $scope.toDoItems = result;
                    $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                        .success(function(resultJson) {
                            $scope.toDoCompletedItems = resultJson;
                        });
                })
                .error(function(result) {
                    console.log(result);
                });
        }
    };


    $scope.getCompletedTasks = function() {
        var element = document.getElementById("completedList");
        var title = element.getAttribute("title");
        if (title === "hidden") {
            element.setAttribute("title", "active");
            element.setAttribute("class", "tasks");
            $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
                .success(function(result) {
                    $scope.toDoCompletedItems = result;
                })
                .error(function(result) {
                    console.log(result);
                });
        } else if (title === "active") {
            element.setAttribute("title", "hidden");
            element.setAttribute("class", "tasks hidden");
        }
    };

    $scope.doubleClick = function(e) {
        e.preventDefault();
        $("#wrapper-right").toggleClass("toggled");
    }
});