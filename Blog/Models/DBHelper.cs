using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class DBHelper
    {
        static string ConnectString = "server=.;database=Blog;uid=sa;pwd=123456";

        //增删改方法
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                return comm.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                return -1 * ex.Number;
            }
            catch (Exception ex)
            {
                return -1 ;
            }
            finally
            {
                conn.Close();
            }
        }



        //查询方法
        public static object ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectString);
            SqlCommand comm = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return comm.ExecuteScalar();

            }
            catch(SqlException ex)
            {
                return null;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }

            }

        }
        //封装查询多结果方法
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectString);
            SqlCommand comm = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return comm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (SqlException ex)
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
                return null;
            }
           

        }


    }
}