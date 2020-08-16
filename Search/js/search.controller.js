app.controller('SearchController', function ($scope, $http, $window, SessionFactory) {

    var self = this;
    self.users = [];
    self.bookmarks = [];

    $scope.Search = function () {
        var post = $http({
            method: "POST",
            url: "/Home/Search",
            dataType: 'json',
            data: { name: $scope.Name },
            headers: { "Content-Type": "application/json" }
        });

        post.success(function (data, status) {
            if (data.length !== 0) {
                self.users = data;
            }
            else {
                if (name === "" && $scope.Name === undefined) {
                    $window.alert("Enter the name!");
                    self.users = null;
                }
                else {
                    $window.alert("No data by name : " + $scope.Name);
                    self.users = null;
                }              
            }         

        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    },

    $scope.Save = function (user) {

        var post = $http({
            method: "POST",
            url: "/Home/Save",
            datatype: "json",
            data: user
        });

        post.success(function (data, status) {
            SessionFactory.setMSG(data);
        });
    };
});