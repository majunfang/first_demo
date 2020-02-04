using Blog.Areas.Admin.Models.DBModel;
using Blog.Models;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models.DAL
{
    public class RecommendService

    {
        //更新推荐
        public static int  UpdateRecomm(RecArticlescs arc)
        {
            string sql = string.Format("update [dbo].[RecArticles] set ArticleId={0},PosId={1},Weight={2} where Id='{3}'", arc.ArticleId, arc.PosId, arc.Weight, arc.Id);
            int count = DBHelper.ExecuteNonQuery(sql);
            return count;

        }






        //根据Id获取推荐
        public static RecArticlescs GetRecomById(string Id)
        {
            RecArticlescs art = null;
            string sql = string.Format("select a.*,b.Title from [dbo].[RecArticles] a join [dbo].[Articles] b on b.Id=ArticleId where a.Id={0}", Id);
            using(SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    art=new RecArticlescs
                    {
                        Id = dr["Id"].ToString(),
                        ArticleId = dr["ArticleId"].ToString(),
                        PosId = dr["PosId"].ToString(),
                        Weight = dr["Weight"].ToString(),
                        Title = dr["Title"].ToString(),

                    };
                }
            }
            return art;

        }

        //获取所有推荐文章
        public static List<RecArticlescs> getRecomPage(int page, int limit,
                                        string Title)
        {
            List<RecArticlescs> list = new List<RecArticlescs>();
            string sql = string.Format("select Top {0} a.*, b.Title from [dbo].[RecArticles] a join [dbo].[Articles] b on a.ArticleId=b.Id where a.Id not in(select top {1} Id from [dbo].[RecArticles] order by Id)", limit, (page - 1) * 10);
            if (!string.IsNullOrEmpty(Title))
            {
                sql += string.Format("and b.Title like '%{0}%'", Title);
            }
            sql += "order by Id";
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new RecArticlescs
                    {
                          Id= dr["Id"].ToString(),
                          ArticleId = dr["ArticleId"].ToString(),
                        PosId = dr["PosId"].ToString(),
                        Weight = dr["Weight"].ToString(),
                        Title = dr["Title"].ToString(),

                    });

                }

            }


            return list;

        }
    }
}