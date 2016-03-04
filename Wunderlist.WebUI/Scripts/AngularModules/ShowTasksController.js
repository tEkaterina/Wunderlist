app.controller('ShowTasksController', function ($scope, $location, service, shareData) {
    loadAllTasksRecords();

    function loadAllTasksRecords() {
        var promiseGetTask = service.getTasks();

        promiseGetTask.then(function (pl) { $scope.Students = pl.data },
              function (errorPl) {
                  $scope.error = errorPl;
              });
    }
});