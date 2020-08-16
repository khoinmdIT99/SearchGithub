var app = angular.module('MyApp', ["ngRoute"]);

app.config(function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('!');
    $routeProvider
        .when("/bookmarks", {
            templateUrl: "/HtmlTemplate/bookmarks.htm",
            controller: 'BookmarksController'
        })
        .when("/", {
            templateUrl: "/HtmlTemplate/search.htm",
            controller: 'SearchController'
        });
});

