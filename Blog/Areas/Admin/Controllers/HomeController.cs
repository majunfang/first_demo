using Blog.Areas.Admin.Models.DAL;
using Blog.Areas.Admin.Models.DBModel;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Areas.Admin.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        //欢迎页面
        public ActionResult Welcome()
        {
            return View();
        }

        // GET: Admin/Home主页
        public ActionResult Index()
        {
            return View();
        }
        //修改密码页面
        public ActionResult Reset()
        {
             string UserName = HttpContext.User.Identity.Name;
            ViewBag.A = UserName;
            return View();
        }
        //修改密码接口
        [HttpPost]
        public ActionResult Reset(User user)
        {  
            User use = UserService.GetUserByName(user.UserName);
            if (user.Password != use.Password)
            {
                return Json(new UIResult(false, "编辑失败"));
            }
            int count = UserService.UpdatePsw(user);
            if (count >= 1)
            {
                return Json(new UIResult(true, "编辑成功"));
            }
            else
            {
                return Json(new UIResult(false, "编辑失败"));
            }
        }
        //登录页面
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //个人信息
        public ActionResult Info()
        {
            //获取通行证中的用户名
            string UserName = HttpContext.User.Identity.Name;
            User user = UserService.GetUserByName(UserName);
            return View(user);
        }
        //编辑个人信息
        [HttpPost]
        [ValidateInput(false)]//可以提交富文本
        public ActionResult Info(User user)
        {
            int count = UserService.UpdateInfo(user);
            if (count >= 1)
            {
                return Json(new UIResult(true, "编辑成功"));
            }
            else
            {
                return Json(new UIResult(false, "编辑失败"));
            }
          

        }
        //登录请求
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u)
        {
            //Redirect("~/Admin/Home/Index");
            User user = UserService.GetUserByName(u.UserName);
            if (user == null)
            {
                return Json(new UIResult(false, "用户名不存在"));
            }else
            {
                if (u.Password == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);//颁发通行证
                    user.LastLoginTime = DateTime.Now;
                    UserService.UpdateDate(user);
                    return Json(new UIResult(true, ""));
                }
                else
                {
                    return Json(new UIResult(false, "密码不正确"));
                }
            }

          
        }



    }
}