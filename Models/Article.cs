using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFootballWebsite.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleCreated { get; set; }
        public string ArticleSubmittedBy { get; set; }
    }
}