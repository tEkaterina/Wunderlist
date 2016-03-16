/// <reference path="UserProfileController.js" />
var app = angular.module("WunderlistModule", []);

app.controller('UpdateNamesCtrl', function ($scope, $http) {

    var currentElementId = undefined;
    var listName = undefined;
    var listId = undefined;

    function setValueFieldListname(name) {
        var elem = document.getElementById('listname');
        elem.value = name;
    }

    $scope.$on("getListNameEvent", function (event, args) {
        listName = args.listname;
        listId = args.listId;
    });

    $scope.$on("editNameEvent", function (event, args) {
        $scope.nameOperation = args.operation;
        currentElementId = args.item.Id;
        window.location.href = '#createTask';
        setValueFieldListname(args.item.Name);
    });

    function renameToDoList(listItemId, listname) {
        $http.post("/ListTasks/RenameToDoList", { listItemId: listItemId, listname: listname })
                    .success(function (result) {
                        $scope.$root.$broadcast("createListEvent", {
                            toDoLists: result
                        });
                    })
                    .error(function (result) {
                        console.log(result);
                    });
    }

    $scope.savedata = function (toDoList) {
        setValueFieldListname("");
        if ($scope.nameOperation === undefined) {
            $http.post("/ListTasks/AddToDoList", { name: toDoList.Name })
                .success(function (result) {
                    $scope.$root.$broadcast("createListEvent", {
                        toDoLists: result
                    });
                })
                .error(function (result) {
                    console.log(result);
                });
        }
        if ($scope.nameOperation === "Переименовать список") {
            var listItemId = currentElementId;
            var listname = toDoList.Name;
            renameToDoList(listItemId, listname);
        }
        if ($scope.nameOperation === "Переименовать задачу") {
            var taskItemId = currentElementId;
            var taskName = toDoList.Name;
            $http.post("/ToDoItem/RenameToDoItem", { taskItemId: taskItemId, taskname: taskName, listname: listName })
                    .success(function (result) {
                        $http.post("/ToDoItem/GetCompletedToDoItems", { listId: listId })
                        .success(function (resultJson) {
                            $scope.$root.$broadcast("renameToDoItemEvent", {
                                toDoItems: result,
                                toDoCompletedItems: resultJson
                            });
                        });
                    })
                    .error(function (result) {
                        console.log(result);
                    });
            
        }
        $scope.nameOperation = undefined;
    }
});