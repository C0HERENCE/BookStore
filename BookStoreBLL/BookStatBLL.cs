using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using BookStoreDAL;
using Newtonsoft.Json;
using BookStoreMisc;


namespace BookStoreBLL
{
    public class BookStatBLL
    {
        public static int GetBookOnSaleCount()
        {
            return BookStatDAL.SelectBookOnSaleCount();
        }

        public static string GetAllBooks()
        {
            return JsonConvert.SerializeObject(BookStatDAL.SelectAllBooks());
        }

        public static string SetBookOnSale(int id, int onsale)
        {
            string msg = "成功";
            if (BookStatDAL.UpdateBookOnSale(id, onsale) > 0)
            {
                msg = "失败";
            }
            return msg;
        }

        public static List<BookStatModel> GetNewestBooks(int count)
        {
            List<BookStatModel> books = new List<BookStatModel>();
            var reader = BookStatDAL.SelectNewestBooksOnSale(count);
            while (reader.Read())
            {
                BookStatModel book = new BookStatModel(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetInt32(6),
                    reader.GetDouble(7),
                    reader.GetInt32(8),
                    reader.GetDateTime(9),
                    reader.GetDouble(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(16),
                    reader.GetString(17),
                    reader.GetString(18),
                    reader.GetInt32(19)
                    );
                books.Add(book);
            }
            return books;
        }
        public static List<BookStatModel> GetHighestStarsBooks(int count)
        {
            List<BookStatModel> books = new List<BookStatModel>();
            var reader = BookStatDAL.SelectHighestStarsBookOnSale(count);
            while (reader.Read())
            {
                BookStatModel book = new BookStatModel(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetInt32(6),
                    reader.GetDouble(7),
                    reader.GetInt32(8),
                    reader.GetDateTime(9),
                    reader.GetDouble(10),
                    reader.GetString(11),
                    reader.GetString(12),
                    reader.GetString(13),
                    reader.GetString(14),
                    reader.GetString(15),
                    reader.GetString(16),
                    reader.GetString(17),
                    reader.GetString(18),
                    reader.GetInt32(19)
                    );
                books.Add(book);
            }
            return books;
        }
    }
}