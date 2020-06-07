using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ppll
{
    public class SqlHelper
    {
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["sqlConnStr"].ConnectionString;

        public static int ExecuteNonQuery(string sqlStr, SqlParameter[] paras)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                int a = 2;
                return 0;
            }
        }


        public static DataTable ExecuteDataTable(string sqlStr, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
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

        public static object ExecuteScalar(string sqlStr, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteDataReader(string sqlStr, SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
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
