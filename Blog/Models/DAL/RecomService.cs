using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models.DAL
{    //推荐文章
    public class RecomService
    {
        public static List<Articles> GetRecomList()
        {
            List<Articles> list = new List<Articles>();
            string sql = "select a.*   from dbo.Articles a  join dbo.RecArticles b on b.ArticleId=a.Id";

            using(SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Articles {
                        Id = dr["Id"].ToString(),
                        Title = dr["Title"].ToString(),
                      
                    });

                }
            }


            return list;
        }
    }
}