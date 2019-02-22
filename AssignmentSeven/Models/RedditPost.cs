using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentSeven.Models
{
    public class RedditPost
    {
        public string Title { get; set; }
        public string LinkURL { get; set; }
        public string Thumbnail { get; set; }

        public RedditPost(string title, string linkUrl, string thumbnail)
        {
            this.Title = title;
            this.LinkURL = linkUrl;
            this.Thumbnail = thumbnail;
        }

    }
}