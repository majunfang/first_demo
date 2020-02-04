using Blog.Models;
using Blog.Models.DAL;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        //我的日记
        // GET: Article
        public ActionResult Index(string keyboard)
        {
            List<UIData> list = HomeService.GetArticlesList("文章", keyboard);
            //分类和文章个数
            List<Classify> classList = HomeService.GetClassifyList();
            //推荐文章
            List<Articles> recomList = RecomService.GetRecomList();
            //点击量最多的前8条
            List<Articles> topList = HomeService.GetTopEight();
            //获取所有标签
            List<string> tagList = HomeService.getTagList();
            ViewBag.A = list;
            ViewBag.B = classList;
            ViewBag.C = recomList;
            ViewBag.D = topList;
            ViewBag.E = tagList;
            return View();
        }
    }
}