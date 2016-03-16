app.controller('ToDoListsController', function ($scope, $http) {

    $scope.toDoList = "";
    $scope.toDoCompletedItems = "";
    var currentlistId = undefined;

    $scope.$root.$broadcast("editNameEvent", {
        nameOperation: "Создать список"
    });

    $http.get("/ListTasks/GetToDoLists")
    .success(function (result) {
        $scope.toDoList = result;
        var element = document.getElementById("taskScroll");
        element.setAttribute("class", "tasks-scroll hidden");
    })
    .error(function (result) {
        console.log(result);
    });

    $scope.$on("createListEvent", function (event, args) {
        $scope.toDoList = args.toDoLists;
    });

    $scope.selectList = function (item) {
        var element = document.getElementById("taskScroll");
        element.setAttribute("class", "taskScroll");
        var listname = item.Name;
        currentlistId = item.Id;
        $scope.$root.$broadcast("changeSelectListEvent", {
            listname: listname,
            currentlistId: currentlistId
        });
        $scope.$root.$broadcast("getListNameEvent", {
            listname: listname,
            listId: currentlistId
        });
    };

    $scope.deleteList = function () {
        var listname = $scope.namelist;
        var listItemId = this.listItem.Id;
        $http.put("/ListTasks/DeleteToDoList", { listItemId: listItemId, listname: listname })
                .success(function (result) {
                    $scope.toDoList = result;
                    $scope.$root.$broadcast("renameToDoItemEvent", {
                        toDoItems: "",
                        toDoCompletedItems: ""
                    });
                })
                .error(function (result) {
                    console.log(result);
                });
    }

    $scope.renameList = function (listItem) {
        $scope.$root.$broadcast("editNameEvent", {
            operation: "Переименовать список",
            item: listItem
        });
    }

});