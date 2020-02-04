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
    public class HomeController : Controller
    {
        // GET: Home文章列表页面
        public ActionResult Index(string keyboard)
        {   //文章列表
            List<UIData> list=HomeService.GetArticlesList("", keyboard);
            //个人信息
            User user = AboutService.getUser();
            //6张照片
            List<Photos> photos = PhotosService.GetPhotos();
            //分类和文章个数
            List<Classify> classList = HomeService.GetClassifyList();
            //推荐文章
            List<Articles> recomList = RecomService.GetRecomList();
            ViewBag.A = list;
            ViewBag.B = user;
            ViewBag.C = photos;
            ViewBag.D = classList;
            ViewBag.E = recomList;
            return View(list);
        }
        //文章详情
        public ActionResult Detail(string Id)
        {
            Articles art = HomeService.EetArticlesDetail(Id);
            return View(art);
        }

    }
}