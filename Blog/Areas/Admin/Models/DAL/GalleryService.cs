using Blog.Models;
using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models.DAL
{
    public class GalleryService
    {
        //编辑相册
        public static int EditPhotos(Photos photo)
        {
           string sql=string.Format("update [dbo].[Photos] set PicUrl='{0}',Cont='{1}',BelongToArticles='{2}' where Id='{3}'", photo.PicUrl, photo.Cont, photo.BelongToArticles, photo.Id);
            int count = DBHelper.ExecuteNonQuery(sql);
            return count;
        }

        //新增相册
        public static int AddPhotos(Photos photo)
        {
            string sql = string.Format(@"INSERT INTO [dbo].[Photos]
           (PicUrl
           ,Cont
           ,BelongToArticles)
            VALUES
           ('{0}'
           , '{1} '
           , '{2} ')", photo.PicUrl, photo.Cont, photo.BelongToArticles);
            int count = DBHelper.ExecuteNonQuery(sql);
            return count;
        }


        //获取所有的相册
        public static List<Photos> getPhotosPage(int page, int limit,
                                        string BelongToArticles)
        {
            List<Photos> list = new List<Photos>();
            string sql = string.Format("select top {0} a.*,b.Title from [dbo].[Photos] a join [dbo].[Articles] b on b.Id=BelongToArticles where a.Id not in(select top {1} Id from [dbo].[Articles] order by Id)", limit, (page - 1) * 10);
            if (!string.IsNullOrEmpty(BelongToArticles))
            {
                sql += string.Format("and BelongToArticles = '{0}'", BelongToArticles);
            }
            sql += "order by Id";
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Photos
                    {
                        Id = dr["Id"].ToString(),
                        PicUrl = dr["PicUrl"].ToString(),
                        Cont = dr["Cont"].ToString(),
                        BelongToArticles = dr["BelongToArticles"].ToString(),
                        Title = dr["Title"].ToString(),

                    });
                }
            }


            return list;

        }

        //通过Id获取单条相册
        public static Photos GetById(string Id)
        {
            string sql = string.Format("select a.*,b.Title from [dbo].[Photos] a join [dbo].[Articles] b on b.Id=BelongToArticles where a.Id={0}", Id);
            Photos art = null;
            using (SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    art = new Photos
                    {
                        Id = dr["Id"].ToString(),
                        PicUrl = dr["PicUrl"].ToString(),
                        Cont = dr["Cont"].ToString(),
                        BelongToArticles = dr["BelongToArticles"].ToString(),
                        Title = dr["Title"].ToString(),

                    };
                }
            }
            return art;
        }
    }
}