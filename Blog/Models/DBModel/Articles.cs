using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.DBModel
{
    public class Articles
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public string ReadTimes { set; get; }
        public string Tags { set; get; }
        public string SimpleInfo { set; get; }
        public string Cont { set; get; }
        public string MainPicUrl { set; get; }
        public string Source { set; get; }
        public string Type { set; get; }
        public string CreateTime { set; get; }
        public string PubTime { set; get; }
        public string IsPub { set; get; }
        public string ShowType { set; get; }

    }
}