app.controller('TaskToDoItemController', function ($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    $scope.nameOperation = "Создать список";
    var currentlistId = undefined;

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

    $scope.$on("changeSelectListEvent", function (event, args) {
        $scope.namelist = args.listname;
        currentlistId = args.currentlistId;
        $scope.toDoItems = getToDoItemsByListName($scope.namelist);
        $scope.toDoCompletedItems = getCompletedToDoitemsByListId();
    });

    $scope.addToDoItem = function (todoitem) {
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

    $scope.doubleClick = function(e) {
        e.preventDefault();
        $("#wrapper-right").toggleClass("toggled");
    }

});