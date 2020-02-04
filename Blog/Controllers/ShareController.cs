using Blog.Models;
using Blog.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ShareController : Controller
    {
        // GET: Share 相册列表
        public ActionResult Index(string keyboard)
        {
            List<UIData> list = HomeService.GetArticlesList("相册", keyboard);
            return View(list);
        }
    }
}