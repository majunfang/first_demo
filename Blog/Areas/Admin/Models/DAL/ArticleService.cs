
using Blog.Models;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models.DAL
{
    public class ArticleService
    {
        //通过Id编辑文章
        public static int EditArticles(Articles arc)
        {
            string sql = string.Format(@"update [dbo].[Articles] set 
             Title='{0}'
            , Tags='{1}'
            , MainPicUrl='{2}'
             , Source='{3}'
            , Type='{4}'
            , ShowType='{5}'
            , IsPub='{6}'
            , SimpleInfo='{7}'
            , Cont='{8}'
            where Id='{9}'", 
           arc.Title, arc.Tags, arc.MainPicUrl, arc.Source
           , arc.Type, arc.ShowType, arc.IsPub, arc.SimpleInfo
           , arc.Cont, arc.Id);
            int count = DBHelper.ExecuteNonQuery(sql);
            return count;
        }




        //获取文章列表
        public static List<Articles> GetArticlesAll()
        {
            List<Articles> list = new List<Articles>();
            string sql = "select Id,Title from [dbo].[Articles] ";
            

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
    
    //通过Id删除
    public static int  DelById(string Id)
        {
            string sql = string.Format("DELETE FROM [dbo].[Articles] WHERE  Id={0}", Id);
            int count = DBHelper.ExecuteNonQuery(sql);
            return count;
        }


        //通过Id获取单条文章
        public static Articles  GetById(string Id)
        {
            string sql = string.Format("select * from [dbo].[Articles] where Id={0}", Id);
            Articles art = null;
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    art = new Articles
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
      
        //新增文章
        public static int AddArticle(Articles art)
        {
            art.CreateTime = DateTime.Now.ToString();
            if (art.IsPub == "是")
            {
                art.PubTime = DateTime.Now.ToString();
            }
            else
            {
                art.PubTime = "";
            }
            string sql =string.Format(@"insert into [dbo].[Articles](
             Title
           ,ReadTimes
           ,Tags
           ,SimpleInfo
           ,Cont
           ,MainPicUrl
           ,Source
           ,Type
           ,CreateTime
           ,PubTime
           ,IsPub
           ,ShowType)
           values(
           '{0}',
           {1},
           '{2}',
           '{3}',
           '{4}',
           '{5}',
           '{6}', 
           '{7}',
           '{8}',
           '{9}',
           '{10}',
           '{11}')", art.Title,
           0,
           art.Tags,
           art.SimpleInfo,
           art.Cont,
           "",
           art.Source,
           art.Type,
           art.CreateTime,
           art.PubTime,
           art.IsPub,
           art.ShowType);

            int count = DBHelper.ExecuteNonQuery(sql);
            return count;
        }
        //获取所有的文章分页
        public static List<Articles> getArticlePage(int page, int limit,
                                        string Title, string Start,
                                        string End, string IsPub)
        {
            List<Articles> list = new List<Articles>();
            string sql = string.Format("select top {0} * from [dbo].[Articles] where Id not in(select top {1} Id from [dbo].[Articles] order by Id)", limit, (page - 1) * 10);
            if (!string.IsNullOrEmpty(Title))
            {
                sql += string.Format("and Title like '%{0}%'", Title);
            }
            if (!string.IsNullOrEmpty(Start))
            {
                sql += string.Format("and PubTime >'{0}'", Start);
            }

            if (!string.IsNullOrEmpty(End))
            {
                sql += string.Format("and PubTime <'{0'}", End);
            }
            if (!string.IsNullOrEmpty(IsPub))
            {
                sql += string.Format("and IsPub ='{0}'", IsPub);
            }

            sql += "order by Id";
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Articles
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
                    });

                }

            }


            return list;

        }
    }
}