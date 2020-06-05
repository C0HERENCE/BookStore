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
    public class AuthorDAL
    {
        public static int InsertAuthor(AuthorModel author)
        {
            string sql = "insert into author values(@name,@intro)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("name", author.name),
                new SqlParameter("intro", author.intro),
            });
        }

        public static int SelectAuthorCount()
        {
            string sql = "select count(*) from author";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public static DataTable SelectAllAuthor()
        {
            string sql = "select * from author";
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}