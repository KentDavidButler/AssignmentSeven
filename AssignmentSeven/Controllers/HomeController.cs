using AssignmentSeven.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


//Everythign is in the about section!!!
namespace AssignmentSeven.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.RedditTopTen = GitTopTen();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<RedditPost> GitTopTen()
        {
            //Everythign is in the about section!!!
            string URL = "https://www.reddit.com/r/aww/.json";

            HttpWebRequest request = WebRequest.CreateHttp(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());

            string APIText = sr.ReadToEnd();
            sr.Close();

            JToken personData = JToken.Parse(APIText);

            List<RedditPost> TopTen = new List<RedditPost>();
            for (int i = 0; i < 11; i++)
            {
                string title = personData["data"]["children"][i+1]["data"]["title"].ToString();
                string url = personData["data"]["children"][i + 1]["data"]["url"].ToString();
                string thumb = personData["data"]["children"][i + 1]["data"]["thumbnail"].ToString();
                TopTen.Add(new RedditPost(title, url, thumb));
            }

            return TopTen;
        }
    }
}