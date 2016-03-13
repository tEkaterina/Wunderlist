var app = angular.module('WunderlistModule');

app.controller('userProfileController', function($scope, $http) {
    $http.get("/UserProfile/GetUserInfo")
        .success(function (userProfile) {
            $scope.userProfile = userProfile;
        })
        .error(function (result) {
            console.log(result);
        });
});