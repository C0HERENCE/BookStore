using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BookStoreDAL;
using BookStoreMisc;

namespace BookStoreBLL
{
    public class PublisherBLL
    {
        public static string AddPublisher(PublisherModel publisher)
        {
            string msg = "插入出版社失败";
            if (PublisherDAL.InsertPublisher(publisher) == 1)
            {
                msg = "插入出版社成功";
            }
            return msg;
        }

        static public int GetPublisherCount()
        {
            return PublisherDAL.SelectPublisherCount();
        }

        static public string GetAllPublisher()
        {
            return JsonConvert.SerializeObject(PublisherDAL.SelectAllPublisher());
        }

        static public int GetPublisherIDByname(string name)
        {
            object id = PublisherDAL.SelectPublisherIDByName(name);
            if (id != null) 
            {
                id = (int)id;
            }
            else
            {
                id = -1;
            }
            return (int)id;
        }
    }
}