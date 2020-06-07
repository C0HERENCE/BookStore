using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreDAL
{
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data;
    public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["sqlConnStr"].ConnectionString;

        public static int ExecuteNonQuery(string sqlStr, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(param);
            conn.Open();
            try
            {

            int s = cmd.ExecuteNonQuery();
                conn.Close();
                return s;
            }
            catch (Exception ee)
            {
                string s = ee.Message;
                int a = 3;
                throw;
            }
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
            //    {
            //        cmd.Parameters.AddRange(param);
            //        conn.Open();
            //        return cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public static DataTable ExecuteDataTable(string sqlStr, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static DataTable ExecuteDataTable(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static object ExecuteScalar(string sqlStr, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static object ExecuteScalar(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteDataReader(string sqlStr, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                return null;
            }
        }
    }
}
