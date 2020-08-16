using Search.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Search.Controllers
{
    public class HomeController : Controller
    {
        SearchService ss = new SearchService();
        SaveReposService srs = new SaveReposService();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Search(string name)
        {              
            return Json(ss.Search(name));          
        }

        [HttpPost]
        public JsonResult Save(string Avatar, string Full_name)
        {           
            return Json(srs.Save(Avatar, Full_name));
        }
        

        [HttpPost]
        public JsonResult GetBookmarksRepos()
        {
            List<ReposModel> reposModellist = new List<ReposModel>();

            if (Session["SavedBookmarks"] != null)
            {
                reposModellist = (List<ReposModel>)Session["SavedBookmarks"];
            }

            return Json(reposModellist);
        }
    }
}