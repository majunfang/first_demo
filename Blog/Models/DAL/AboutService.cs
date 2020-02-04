using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models.DAL
{
    public class AboutService
    {
        public static User getUser()
        {
            User user = null;
            string sql = "select * from [dbo].[User]";
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
                        LastLoginTime = dr["LastLoginTime"].ToString(),
                        AboutMe = dr["AboutMe"].ToString()
                    };
                }
            }
            return user;
        }
    }
}