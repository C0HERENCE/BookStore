using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookStoreMisc;

namespace BookStoreDAL
{
    public class PublisherDAL
    {
        public static int InsertPublisher(PublisherModel publisher)
        {
            string sql = "insert into publisher values(@name)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("name",publisher.name)
            });
        }
        public static int SelectPublisherCount()
        {
            string sql = "select count(*) from publisher";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public static DataTable SelectAllPublisher()
        {
            string sql = "select * from publisher";
            return SqlHelper.ExecuteDataTable(sql);
        }

        public static object SelectPublisherIDByName(string name)
        {
            string sql = "select id from publisher where name=@name";
            return SqlHelper.ExecuteScalar(sql, new SqlParameter[] {
                new SqlParameter("name",name)
            });
        }
    }
}