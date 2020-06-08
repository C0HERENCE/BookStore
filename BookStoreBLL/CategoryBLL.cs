using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using Newtonsoft.Json;
using BookStoreDAL;

namespace BookStoreBLL
{
    public class CategoryBLL
    {
        static public Dictionary<int, string> GetCategoryDictByRole(int role)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            var reader = CategoryDAL.SelectCategoryByRole(role);
            while (reader.Read())
            {
                dict.Add(reader.GetInt32(0), reader.GetString(1));
            }
            return dict;
        }
        static public List<CategoryModel> GetCategoryByRole(int role)
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            var reader = CategoryDAL.SelectCategoryByRole(role);
            if (reader==null)
            {
                return categories;
            }
            while (reader.Read())
            {
                var a =reader.GetInt32(0);
                var b =reader.GetString(1);
                var c = reader.GetInt32(2);
                categories.Add(new CategoryModel(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2)
                    ));
            }
            return categories;
        }
    }
}