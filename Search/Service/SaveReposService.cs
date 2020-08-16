using Search.Models;
using System.Collections.Generic;
using System.Web;


public class SaveReposService
{
    public SaveReposService()
    {

    }

    public List<ReposModel> Save(string Avatar, string Full_name)
    {
        var context = HttpContext.Current;

        ReposModel reposModel = new ReposModel();
        reposModel.Avatar = Avatar;
        reposModel.Full_name = Full_name;

        List<ReposModel> reposModelistl = new List<ReposModel>();

        if (context.Session["SavedBookmarks"] != null)
        {
            reposModelistl = (List<ReposModel>)context.Session["SavedBookmarks"];

            if (CheckReposToSession(reposModel, reposModelistl))
            {
                reposModelistl.Add(reposModel);
            }
        }
        else
        {
            reposModelistl.Add(reposModel);
        }

        context.Session["SavedBookmarks"] = reposModelistl;
        return reposModelistl;
    }

    public bool CheckReposToSession(ReposModel reposModel, List<ReposModel> reposModelistl)
    {
        bool resultChek = true;
        reposModelistl.ForEach(repos =>
        {
            if (repos.Avatar == reposModel.Avatar && repos.Full_name == reposModel.Full_name)
            {
                resultChek = false;
            }
        });

        return resultChek;
    }

}