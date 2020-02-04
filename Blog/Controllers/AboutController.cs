using Blog.Models.DAL;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            //个人信息
            User user = AboutService.getUser();
            //6张照片
            List<Photos> photos = PhotosService.GetPhotos();

            ViewBag.A = user;
            ViewBag.B = photos;
            return View();
        }
    }
}