var app = angular.module('WunderlistModule');

app.controller('userProfileController', function($scope, $http) {

    $scope.userProfile = {};
    $scope.changedUserProfile = {};

    $scope.loadUserProfile = function () {
        $http.get("/UserProfile/GetUserInfo")
            .success(function(userProfile) {
                $scope.userProfile = userProfile;
                $scope.changedUserProfile = userProfile;
            })
            .error(function(result) {
                console.log(result);
            });
    }

    $scope.loadUserProfile();

    $scope.logout = function() {
        $http.put("/User/Logout", {})
            .success(function(redirectUrl) {
                window.location.href = redirectUrl;
            })
            .error(function(result) {
                console.log(result);
            });
    }

    $scope.loadAvatar = function() {
        var avatar = document.getElementById('avatarInput').files[0], 
            reader = new FileReader();
        reader.onloadend = function(e) {
            var image = e.target.result;
            image = image.replace(/.+?base64 *\, *?/g, "");

            $http.put("/UserProfile/ChangeAvatar", { image: image })
                .success(function(result) {
                    $scope.loadUserProfile();
                })
                .error(function(result) {
                    console.log(result);
                });
        }
        reader.readAsDataURL(avatar);
    }

    $scope.saveUserProfileChanges = function() {
        var newUsername = document.getElementById('username').value;
        $http.put("/UserProfile/ChangeUsername", { newUsername:  newUsername})
            .success(function (result) {
                $scope.loadUserProfile();
                location.reload(false);
            })
            .error(function(result) {
                console.log(result);
            });
    }
});