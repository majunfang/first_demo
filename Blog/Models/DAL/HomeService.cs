using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models.DAL
{
    public class HomeService
    {
        //标签云
        public static List<string> getTagList()
        {
            List<string> list = new List<string>();
            string sql = "select Tags  from dbo.Articles group by Tags";
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(dr["tags"].ToString());
                }
            }
            return list;
        }
        //获取点击量最多的前8条
        public static List<Articles> GetTopEight()
        {
            List<Articles> list = new List<Articles>();
            string sql = "select top 8 * from dbo.Articles order by ReadTimes";

            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Articles
                    {
                        Id = dr["Id"].ToString(),
                        Title = dr["Title"].ToString(),
                    });
                }
            }
            return list;
        }
        //文章分类和个数
        public static List<Classify> GetClassifyList()
        {
            List<Classify> list = new List<Classify>();
            string sql = "select Type,COUNT(*) as count from dbo.Articles group by Type";
            using(SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Classify { Type = dr["Type"].ToString(), Count = dr["Count"].ToString() });

                }
            }
            return list;
        }

        //获取文章详情
        public static Articles EetArticlesDetail(string Id)
        {
            string sql = string.Format("select * from [dbo].[Articles] where Id={0}", Id);
            Articles art = null;
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    art=new Articles
                    {
                        Id = dr["Id"].ToString(),
                        Title = dr["Title"].ToString(),
                        ReadTimes = dr["ReadTimes"].ToString(),
                        SimpleInfo = dr["SimpleInfo"].ToString(),
                        Cont = dr["Cont"].ToString(),
                        MainPicUrl = dr["MainPicUrl"].ToString(),
                        Source = dr["Source"].ToString(),
                        Type = dr["Type"].ToString(),
                        CreateTime = dr["CreateTime"].ToString(),
                        PubTime = dr["PubTime"].ToString(),
                        IsPub = dr["IsPub"].ToString(),
                        ShowType = dr["ShowType"].ToString()

                    };
                }
            }
            return art;
        }

        //搜索文章列表
       

        //获取文章列表
        public static List<UIData> GetArticlesList(string ShowType,String keyboard)
        {
            List<UIData> list = new List<UIData>();
            string sql = "select Id,Title,SimpleInfo,MainPicUrl from [dbo].[Articles] where IsPub='是'";
            if (!string.IsNullOrEmpty(ShowType))
            {
                 sql = string.Format("select Id,Title,SimpleInfo,MainPicUrl from [dbo].[Articles] where ShowType='{0}' and IsPub='是'", ShowType);
            }
            if (!string.IsNullOrEmpty(keyboard))
            {
                sql += string.Format(" and Title like '%{0}%'", keyboard);
            }
           
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new UIData
                    {
                        Id = dr["Id"].ToString(),
                        PicUrl = dr["MainPicUrl"].ToString(),
                        Title = dr["Title"].ToString(),
                        Data = dr["SimpleInfo"]
                    });
                }
            }
            return list;

        }
    }
}