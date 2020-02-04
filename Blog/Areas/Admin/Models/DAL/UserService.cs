using Blog.Areas.Admin.Models.DBModel;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models.DAL
{
    public class UserService
    {
        //修改密码
        public static int UpdatePsw(User user)
        {
            string sql = string.Format("update [dbo].[User] set Password='{0}' where UserName='{1}'", user.NewPsw, user.UserName);
            int value = DBHelper.ExecuteNonQuery(sql);
            return value;
        }

        //修改最后一次登录时间

        public static int UpdateDate(User user)
        {
            string sql = string.Format("update [dbo].[User] set LastLoginTime='{0}' where UserName='{1}'", user.LastLoginTime, user.UserName);
            int value = DBHelper.ExecuteNonQuery(sql);
            return value;
        }
        //更新个人信息
          public static int UpdateInfo(User user)
        {
            string sql = string.Format(@"update [dbo].[User] set 
                                        ,SelfSlogo='{0}' 
                                        ,SelfPhoto='{1}'
                                        ,AboutMe='{2}'
                                         where UserName='{3}'"
                                        ,user.SelfSlogo, user.SelfSlogo, user.AboutMe, user.UserName);

            int value = DBHelper.ExecuteNonQuery(sql);
            return value;
        }






        //通过用户名获取用户信息
        public static User GetUserByName(string UserName)
        {
            User user = null;
            string sql = string.Format("select * from [dbo].[User] where UserName='{0}'", UserName);
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {

                    user = new User
                    {
                        UserName = dr["UserName"].ToString(),
                        Password = dr["Password"].ToString(),
                        SelfSlogo = dr["SelfSlogo"].ToString(),
                        SelfPhoto = dr["SelfPhoto"].ToString(),
                        LastLoginTime = DateTime.Parse(dr["LastLoginTime"].ToString()),
                        AboutMe = dr["AboutMe"].ToString(),

                    };
                }
            }
            return user;
        }
    }
}