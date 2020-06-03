using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookStoreDAL;
using Newtonsoft.Json;

namespace BookStoreBLL
{
    public class BookBLL
    {
        public class LayUITable
        {
            public int code = 1;
            public string msg = "failed";
            public int count =0;
            public DataTable data = new DataTable();
        }
        public class LayUIDelBook
        {
            public int code = 1;
            public string msg = "failed";
        }

        public static string GetAllBooks(int page, int limit)
        {
            LayUITable table = new LayUITable();
            table.code = 0;
            table.count = BookInfoDAL.GetBookCount();
            if (page == -1 || limit == -1)
                table.data = BookInfoDAL.GetAllBooks();
            else
                table.data = BookInfoDAL.GetAllBooks((page - 1) * limit, limit);
            table.msg = "success";
            return JsonConvert.SerializeObject(table);
        }

        public static string DelBook(int bookid,int delNew)
        {
            LayUIDelBook delBook = new LayUIDelBook();
            if (BookInfoDAL.DelBook(bookid, delNew) ==1)
            {
                delBook.code = 0;
                delBook.msg = "success";
            }
            else
            {
                delBook.code = 1;
                delBook.msg = "failed";
            }
            return JsonConvert.SerializeObject(delBook);
        }

        public static string BatchDelBook(int[] bookid,int delnew)
        {
            LayUIDelBook delBook = new LayUIDelBook();
            List<int> failedids = new List<int>() ;
            foreach (int id in bookid)
            {
                LayUIDelBook delBook1 = (LayUIDelBook)JsonConvert.DeserializeObject(DelBook(id, delnew), typeof(LayUIDelBook));
                if (delBook1.code == 0) 
                {
                    failedids.Add(id);
                }
            }
            if (failedids.Count==0)
            {
                delBook.code = 0;
                delBook.msg = "success";
            }
            else
            {
                delBook.code = 1;
                delBook.msg = "failed " + failedids.Count.ToString();
            }
            return JsonConvert.SerializeObject(delBook);
        }

        public static int GetBookCount()
        {
            return BookInfoDAL.GetBookCount();
        }
    }
}