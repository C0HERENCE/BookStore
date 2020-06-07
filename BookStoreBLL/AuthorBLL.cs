using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BookStoreMisc;
using BookStoreDAL;

namespace BookStoreBLL
{
    public class AuthorBLL
    {
        static public string AddAuthor(AuthorModel author)
        {
            string msg = "作者信息插入失败";
            if (AuthorDAL.InsertAuthor(author) == 1)
            {
                msg= "作者信息插入成功";
            }
            return msg;
        }

        static public int GetAuthorCount()
        {
            return AuthorDAL.SelectAuthorCount();
        }
        
        static public string GetAllAuthor()
        {
            return JsonConvert.SerializeObject(AuthorDAL.SelectAllAuthor());
        }
        static public int GetAuthorIDByname(string name)
        {
            object id = AuthorDAL.SelectAuthorIDByName(name);
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