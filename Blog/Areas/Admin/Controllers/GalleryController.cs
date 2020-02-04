using Blog.Areas.Admin.Models.DAL;
using Blog.Models;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            List<Articles> list = ArticleService.GetArticlesAll();
            return View(list);
        }
        //新增相册
        public ActionResult Add()
        {
            List<Articles> list = ArticleService.GetArticlesAll();
            return View(list);
        }
        //编辑相册
        public ActionResult Edit(string Id)
        {
            List<Articles> list = ArticleService.GetArticlesAll();
            Photos pho = GalleryService.GetById(Id);
            ViewBag.A = list;
            ViewBag.B = pho;
            return View();
        }
        //编辑相册接口
        [HttpPost]
        [ValidateInput(false)]//可以提交富文本
        public ActionResult Edit(Photos photo)
        {
            int count = GalleryService.EditPhotos(photo);
            if (count >= 1)
            {
                return Json(new UIResult(true, "编辑成功"));
            }
            else
            {
                return Json(new UIResult(false, "编辑失败"));
            }
        }
        //新增相册接口
        [HttpPost]
        [ValidateInput(false)]//可以提交富文本
        public ActionResult Add(Photos photo)
        {
            int count = GalleryService.AddPhotos(photo);
            if (count >= 1)
            {
                return Json(new UIResult(true, "新增成功"));
            }
            else
            {
                return Json(new UIResult(false, "新增失败"));
            }
        }

        public ActionResult GalleryList(int page, int limit,
                                      string BelongToArticles)
        {
            //获取总条数
            string sql1 = string.Format("select Count(*) from [dbo].[Photos]");
            if (!string.IsNullOrEmpty(BelongToArticles))
            {
                sql1 += string.Format("where BelongToArticles={0}", BelongToArticles);
            }
            int cou = Convert.ToInt32(DBHelper.ExecuteScalar(sql1));

            List<Photos> List = GalleryService.getPhotosPage(page, limit, BelongToArticles);
            return Json(new { code = 0, msg = "", count = cou, data = List }, JsonRequestBehavior.AllowGet);

        }
    }
}