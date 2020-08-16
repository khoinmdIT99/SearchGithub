app.factory('SessionFactory', function ($http) {
    var displayFact = [];

    var addMSG = function (obj) {
        console.log("add :" + obj);
        displayFact = obj;
    };

    var GetBookmarks = function () {
        return $http.post("/Home/GetBookmarksRepos", null, null).then(function (data) {
            return data;
        });
    };

    return {
        GetBookmarks: GetBookmarks,

        setMSG: function (obj) {
            console.log("set :" + obj);
            addMSG(obj);
        },

        getMSG: function () {
            console.log("get " + displayFact);
            return displayFact;
        }
    };
});