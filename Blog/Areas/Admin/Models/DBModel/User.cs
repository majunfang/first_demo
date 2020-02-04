using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models.DBModel
{
    public class User
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string SelfSlogo { set; get; }
        public string SelfPhoto { set; get; }
        public DateTime LastLoginTime { set; get; }
        public string AboutMe { set; get; }
        public string NewPsw { set; get; }
    }
}