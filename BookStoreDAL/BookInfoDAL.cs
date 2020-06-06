using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookStoreMisc;
namespace BookStoreDAL
{
    public class BookInfoDAL
    {
        public static int SelectBookCount()
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from bookinfo_line", null);
        }
        public static object SelectAllBook()
        {
            string sql = "select * from bookinfo_line";
            return SqlHelper.ExecuteDataTable(sql);
        }
        public static int InsertBook(BookInfoModel book)
        {
            string sql = "insert into bookinfo values(@isbn,@title,@origintitle,@subtitle,@image,@author_id,@category_id,@publisher_id,@pubdate,@pages,@price,@summary,@catalog)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("@isbn",book.isbn),
                new SqlParameter("@title",book.title),
                new SqlParameter("@origintitle",book.origintitle),
                new SqlParameter("@subtitle",book.subtitle),
                new SqlParameter("@image",book.image),
                new SqlParameter("@author_id",book.author_id),
                new SqlParameter("@category_id",book.category_id),
                new SqlParameter("@publisher_id",book.publisher_id),
                new SqlParameter("@pubdate",book.pubdate),
                new SqlParameter("@pages",book.pages),
                new SqlParameter("@price",book.price),
                new SqlParameter("@summary",book.summary),
                new SqlParameter("@catalog",book.catalog),
            });
        }
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