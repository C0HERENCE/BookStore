using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BookStoreBLL
{
    public class CategoryBLL
    {
        static public Dictionary<int,string> GetCategoryByRole(int role)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            var reader = BookStoreDAL.CategoryDAL.SelectCategoryByRole(role);
            while (reader.Read())
            {
                dict.Add(reader.GetInt32(0), reader.GetString(1));
            }
            return dict;
        }
    }
}