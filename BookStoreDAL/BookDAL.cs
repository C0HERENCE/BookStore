using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreDAL
{
    public class BookDAL
    {
        public static DataTable GetAllBooks(int offset, int size)
        {
            string sql = "SELECT * FROM book WHERE id IN(SELECT TOP (0+@limit) id FROM book WHERE id NOT IN(SELECT TOP (0+@offset) id FROM book))";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("offset", offset);
            param[1] = new SqlParameter("limit", size);
            return SqlHelper.ExecuteDataTable(sql, param);
        }
        public static DataTable GetAllBooks()
        {
            string sql = "SELECT * FROM book";
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        public static int GetBookCount()
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from book", null);
        }

        public static int DelBook(int bookid, int del)
        {
            string sql = "UPDATE book SET del = @del WHERE id = @id";
            SqlParameter[]  param = new SqlParameter[2];
            param[0] = new SqlParameter("del", del);
            param[1] = new SqlParameter("id", bookid);
            return SqlHelper.ExecuteNonQuery(sql, param);
        }
    }
}