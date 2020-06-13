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
            return (int)SqlHelper.ExecuteScalar("select count(*) from bookinfo_full", null);
        }
        public static object SelectAllBook()
        {
            string sql = "select * from bookinfo_full";
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

        public static DataTable SelectBookByCategory(int i)
        {
            string sql = "select* from bookstat_full where category_role = @category and onsale = @onsale";
            return SqlHelper.ExecuteDataTable(sql,new SqlParameter[] { 
                new SqlParameter("category",i),
                new SqlParameter("onsale",1),
            });
        }

        public static void UpdateBook(BookInfoModel book)
        {
            string sql = @"update bookinfo set 
                            title=@title,
                            origintitle=@origintitle,
                            subtitle=@subtitle,
                            image=@image,
                            category_id=@categoryid,author_id=@author,isbn=@isbn,publisher_id=@publisher,pubdate=@pubdate,pages=@pages,price=@price
                            where id=@id";
            int a = SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("title",book.title),
                new SqlParameter("origintitle",book.origintitle),
                new SqlParameter("subtitle",book.subtitle),
                new SqlParameter("image",book.image),
                new SqlParameter("categoryid",book.category_id),
                new SqlParameter("author",book.author_id),
                new SqlParameter("isbn",book.isbn),
                new SqlParameter("publisher",book.publisher_id),
                new SqlParameter("pages",book.pages),
                new SqlParameter("price",book.price),
                new SqlParameter("id",book.id),
                new SqlParameter("pubdate",book.pubdate),
            });
        }
    }
}