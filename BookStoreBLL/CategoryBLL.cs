using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BookStoreBLL
{
    public class CategoryBLL
    {
        static public string GetCategory(int role)
        {
            return JsonConvert.SerializeObject(BookStoreDAL.CategoryDAL.GetCategoryRole(role));
        }
    }
}