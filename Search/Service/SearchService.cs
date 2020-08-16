using Search.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

public class SearchService
{
    public SearchService()
    {

    }

    public List<ReposModel> Search(string name)
    {
        List<ReposModel> repos = new List<ReposModel>();
        string avatar_url = "";
        string full_name = "";
        string url = "https://api.github.com/search/repositories?q=" + name;
            
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;

        if (webRequest != null)
        {
            webRequest.Method = "GET";
            webRequest.UserAgent = "Anything";
            webRequest.ServicePoint.Expect100Continue = false;

            try
            {
                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    string reader = responseReader.ReadToEnd();

                    var o = Newtonsoft.Json.Linq.JObject.Parse(reader);
                    int count = o["items"].Count();

                    for (int i = 0; i < count; i++)
                    {
                        var items = o["items"][i];

                        if (items != null)
                        {
                            full_name = items["full_name"].ToString();
                            var owner = items["owner"];

                            if (owner != null)
                            {
                                avatar_url = (owner["avatar_url"].ToString());
                            }

                            ReposModel userModel = new ReposModel();
                            userModel.Avatar = avatar_url;
                            userModel.Full_name = full_name;
                            repos.Add(userModel);
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        return repos;
    }

}