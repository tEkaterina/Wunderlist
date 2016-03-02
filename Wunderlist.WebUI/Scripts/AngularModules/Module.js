var app = angular.module("WunderlistModule", ["ngRoute"]);  
  
app.factory("ShareData", function () {  
    return { value: 0 }  
});  

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {  
    debugger;  
    $routeProvider.when('/ShowTasks',  
                        {  
                            templateUrl: 'Main/ShowTasks',
                            controller: 'ShowTasksController' 
                        });   
    $routeProvider.otherwise(  
                        {  
                            redirectTo: '/'  
                        });  
      
    $locationProvider.html5Mode(true).hashPrefix('!')  
}]);  