using Blog.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models.DAL
{
    public class PhotosService
    {   
        //左侧6张照片
        public static List<Photos> GetPhotos()
        {
            List<Photos> list = new List<Photos>();
            string sql = "select * from dbo.Photos where Id<8";
            using(SqlDataReader dr = DBHelper.ExecuteReader(sql))
            {
                while (dr.Read())
                {
                    list.Add(new Photos
                    {
                        Id=dr["Id"].ToString(),
                        PicUrl=dr["PicUrl"].ToString(),
                        Cont= dr["Cont"].ToString(),
                        BelongToArticles= dr["BelongToArticles"].ToString()

                    });
                }
            }
            return list;
        }







    }
}