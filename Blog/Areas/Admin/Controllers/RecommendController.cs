using Blog.Areas.Admin.Models.DAL;
using Blog.Areas.Admin.Models.DBModel;
using Blog.Models;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class RecommendController : Controller
    {
        // GET: Admin/Recommend
        public ActionResult Index()
        {
            List<Articles> list = ArticleService.GetArticlesAll();
            return View(list);
        }

        //编辑推荐
        public ActionResult Edit(string Id)
        {

            List<Articles> list = ArticleService.GetArticlesAll();
            RecArticlescs arc = RecommendService.GetRecomById(Id);
            ViewBag.A = list;
            ViewBag.B = arc;
            return View();
        }
        //编辑推荐提交
        [HttpPost]
        public ActionResult Edit(RecArticlescs arc)
        {
            int count = RecommendService.UpdateRecomm(arc);
            if (count >= 1)
            {
                return Json(new UIResult(true, "编辑成功"));
            }
            else
            {
                return Json(new UIResult(false, "编辑失败"));
            }
           


        }





        public ActionResult RecomList(int page, int limit,
                                     string Title)
        {
            //获取总条数
            string sql1 = string.Format("select Count(*) from Articles");
            int cou = Convert.ToInt32(DBHelper.ExecuteScalar(sql1));

            List<RecArticlescs> List = RecommendService.getRecomPage(page, limit, Title);
            return Json(new { code = 0, msg = "", count = cou, data = List }, JsonRequestBehavior.AllowGet);

        }
    }
}