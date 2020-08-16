
Gregory Kharitonov -- 05/06/2019--
What is it?
----------
This asp.net mvc + angularjs application, to search for GitHub repos by name
and displaying saved bookmarks. Received data from GitHub is limited in scope 
because of the security policy GitHub (A large load on the database).
delete folder .vc before the first launch

Description Metods from HomeController
----------

Index() - displays the view (Index.chtml)

Search(string name) - Search by name repositories using service SearchService,
get the List<ReposModel> repos and create JSON object.

Save(string Avatar, string Full_name) - Saves the data of the selected repository
using service SaveReposService, get the  List<ReposModel> reposModelistl 
and create JSON object.

GetBookmarksRepos() - returns saved data from Session["SavedBookmarks"] if the 
Session["SavedBookmarks"]is empty displays a blank page.

Description Folder Service
----------

SearchService
----------

Search(string name) - Search by name repositories, create webRequest, get the result 
and return List<ReposModel> repos.

SaveReposService

----------

Save(string Avatar, string Full_name) - 

CheckReposToSession(UserModel userModel, List<UserModel> objList) - checks 
the repository in session. If the repository is not in session it is added to 
the session.

Description Folder js
----------

app.js - 

bookmarks.controller.js - call server function GetBookmarksRepos()

search.controller.js - call server function Search(string name), 
Save(string Avatar, string Full_name).

session.factory.js - data record and data acquisition from SessionFactory

Description Folder HtmlTemplate
----------

search.htm - repository search template, use SearchController.

bookmarks.htm - display selected repositories,  use BookmarksController.







