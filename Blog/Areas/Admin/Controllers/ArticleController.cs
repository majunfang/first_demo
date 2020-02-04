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
    public class ArticleController : Controller
    {
        // GET: Admin/Article 
        public ActionResult Index()
        {
            return View();
        }

        //添加文章页面
        public ActionResult Add()
        {
            return View();
        }
        //编辑文章页面
        public ActionResult Edit(string Id)
        {
            Articles arc = ArticleService.GetById(Id);
            return View(arc);
        }
        //编辑文章功能
        [HttpPost]
        [ValidateInput(false)]//可以提交富文本
        public ActionResult Edit(Articles arc)
        {
            int count = ArticleService.EditArticles(arc);
            if (count >= 1)
            {
                return Json(new UIResult(true, "编辑成功"));
            }
            else
            {
                return Json(new UIResult(false, "编辑失败"));
            }
        }
        //删除文章
        public ActionResult Del(string Id)
        {
            Articles arc = ArticleService.GetById(Id);
            return View(arc);
        }
        //新增文章
        [HttpPost]
        [ValidateInput(false)]//可以提交富文本
        public ActionResult Add(Articles art)
        {
            int count = ArticleService.AddArticle(art);
            if (count >= 1)
            {
                return Json(new UIResult(true, "新增成功"));
            }else
            {
                return Json(new UIResult(false, "新增失败"));
            }
        }

        public ActionResult ArticleList(int page, int limit,
                                        string Title, string Start,
                                        string End, string IsPub)
        {
            //获取总条数
            string sql1 = string.Format("select Count(*) from Articles");
            int cou = Convert.ToInt32(DBHelper.ExecuteScalar(sql1));

            List<Articles> List = ArticleService.getArticlePage(page, limit, Title, Start,
                                         End, IsPub);
            return Json(new { code = 0, msg = "", count = cou, data = List }, JsonRequestBehavior.AllowGet);

        }
        //上传封面
        [HttpPost]
        public ActionResult UploadPhoto()
        {
            try
            {
                HttpPostedFileBase postFile = Request.Files["file"];
                if (postFile != null)
                {
                    string fileExt = postFile.FileName.Substring(postFile.FileName.LastIndexOf(".") + 1); //文件扩展名，不含“.”
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    //随机生成新的文件名
                    string upLoadPath = "~/images/"; //上传目录相对路径~表示网站根目录
                    string fullUpLoadPath = Server.MapPath(upLoadPath); //上传目录的物理路径
                    string newFilePath = upLoadPath + newFileName; //上传后的路径
                    postFile.SaveAs(fullUpLoadPath + newFileName); //核心方法
                    return Json(new UIResult(true, "", "images/" + newFileName));
                }
                else
                {
                    return Json(new UIResult(false, "未检测到文件数据"));
                }
            }
            catch (Exception ex)
            {
                return Json(new UIResult(false, "上传失败:" + ex.Message));
            }
        }
    }
}