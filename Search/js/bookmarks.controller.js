app.controller('BookmarksController', function ($scope, SessionFactory) {

    var self = this;
    self.BookmarksSaved = [];

    var GetBookmarks = function () {
        self.BookmarksSaved = SessionFactory.getMSG();
        if (self.BookmarksSaved === null || self.BookmarksSaved === undefined || self.BookmarksSaved.length === 0) {

            SessionFactory.GetBookmarks().then(function (response) {
                console.log(response);
                self.BookmarksSaved = response.data;
            });
        }
    };
    GetBookmarks();
});