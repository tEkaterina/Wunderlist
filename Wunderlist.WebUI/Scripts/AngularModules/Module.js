var app = angular.module("WunderlistModule", ["ngRoute"]);  
  
app.factory("ShareData", function () {  
    return { value: 0 }  
});  

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {  
    debugger;  
    $routeProvider.when('/showtasks',
                        {  
                            templateUrl: 'Main/ShowTasks',
                            controller: 'ShowTasksController' 
                        });   
    $routeProvider.otherwise(  
                        {  
                            redirectTo: '/Main'  
                        });  
      
    $locationProvider.html5Mode(true).hashPrefix('!')  
}]);  