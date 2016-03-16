app.controller('TaskToDoItemController', function ($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;
    var currentTaskId = undefined;

    function getToDoItemsByListName(listname) {
        $scope.toDoItems = "";
        $http.post("/ToDoItem/GetToDoItems", { listName: listname })
                .success(function (result) {
                    $scope.toDoItems = result;
                })
        .error(function (result) {
            console.log(result);
        });
    }

    function getCompletedToDoitemsByListId() {
        $http.post("/ToDoItem/GetCompletedToDoItems", { listId: currentlistId })
            .success(function (resultJson) {
                $scope.toDoCompletedItems = resultJson;
            })
            .error(function (result) {
                console.log(result);
            });
    }

    function getToDoItemNote(toDoItem) {
        var toDoItemId = toDoItem.Id;
        $http.post("/ToDoItem/GetToDoItemNote", { toDoItemId: toDoItemId })
            .success(function(result) {
                $scope.taskitem = result;
            });
    }

    function hiddenRightMenu() {
        $("#wrapper-right").toggleClass("toggled");
    }

    $scope.$on("changeSelectListEvent", function (event, args) {
        $scope.namelist = args.listname;
        currentlistId = args.currentlistId;
        $scope.toDoItems = getToDoItemsByListName($scope.namelist);
        $scope.toDoCompletedItems = getCompletedToDoitemsByListId();
    });

    $scope.$on("renameToDoItemEvent", function (event, args) {
        $scope.toDoItems = args.toDoItems;
        $scope.toDoCompletedItems = args.toDoCompletedItems;
    });
    
    $scope.addToDoItem = function (todoitem) {
        var listname = $scope.namelist;
        if (todoitem.Name !== "") {
            $http.post("/ToDoItem/AddToDoItem", { name: todoitem.Name, listname: listname })
            .success(function (result) {
                $scope.toDoItems = result;
                todoitem.Name = "";
            })
            .error(function (result) {
                console.log(result);
            });
        }
    };

    $scope.deletetoDoItem = function(item) {
        var listname = $scope.namelist;
        var toDoItemId = item.Id;
        $http.put("/ToDoItem/DeleteToDoItem", { taskId: toDoItemId, listname: listname })
            .success(function(result) {
                $scope.toDoItems = result;
                getCompletedToDoitemsByListId();
            })
            .error(function(result) {
                console.log(result);
            });
    }

    $scope.toDoTaskCompleted = function(id, status) {
        if (status) {
            $http.post("/ToDoItem/ChangeTaskStatus", { taskId: id, status: status, listId: currentlistId })
                .success(function(result) {
                    $scope.toDoItems = result;
                    $scope.toDoCompletedItems = getCompletedToDoitemsByListId();
                });
        };
    }

    $scope.renametoDoItem = function (toDoItem) {
        $scope.$root.$broadcast("editNameEvent", {
            operation: "Переименовать задачу",
            item: toDoItem
        });
    }

    $scope.getCompletedTasks = function() {
        var element = document.getElementById("completedList");
        var title = element.getAttribute("title");
        if (title === "hidden") {
            element.setAttribute("title", "active");
            element.setAttribute("class", "tasks");
            getCompletedToDoitemsByListId();
        } else if (title === "active") {
            element.setAttribute("title", "hidden");
            element.setAttribute("class", "tasks hidden");
        }
    };

    $scope.doubleClick = function(e, toDoItem) {
        e.preventDefault();
        hiddenRightMenu();
        currentTaskId = toDoItem.Id;
        $scope.nameTask = toDoItem.Name;
        getToDoItemNote(toDoItem);
    }

    $scope.saveNoteDateToDoItem = function (taskitem) {
        if (taskitem.Note !== "" && currentTaskId !== undefined) {
            var element = document.getElementById("date");
            var date = element.getAttribute("value");
            $http.post("/ToDoItem/AddDueDateAndNote", { taskId: currentTaskId, note: taskitem.Note, dueDate: date, listId: currentlistId })
            .success(function (result) {
                $scope.toDoItems = result;
                hiddenRightMenu();
            })
            .error(function (result) {
                console.log(result);
            });
        }        
    }
});