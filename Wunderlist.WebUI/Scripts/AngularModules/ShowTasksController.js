app.controller('ShowTasksController', function ($scope, $location, service, shareData) {
    window.loadAllTasksRecords();

    function loadAllStudentsRecords() {
        var promiseGetTask = service.getTasks();

        promiseGetTask.then(function (pl) { $scope.Students = pl.data },
              function (errorPl) {
                  $scope.error = errorPl;
              });
    }
});