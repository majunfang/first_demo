using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.DBModel
{
    public class Photos
    {
        public string Id { set; get; }
        public string PicUrl { set; get; }
        public string Cont { set; get; }
        public string BelongToArticles { set; get; }
        public string Title { set; get; }
    }
}