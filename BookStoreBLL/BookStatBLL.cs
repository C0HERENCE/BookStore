using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using BookStoreDAL;
using Newtonsoft.Json;


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

        public static string SetBookOnSale(int id,int onsale)
        {
            string msg = "成功";
            if (BookStatDAL.UpdateBookOnSale(id, onsale) > 0)
            {
                msg = "失败";
            }
            return msg;
        }
    }
}