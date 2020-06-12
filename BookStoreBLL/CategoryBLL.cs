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
            if (!reader.IsClosed) reader.Close();
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
                categories.Add(new CategoryModel(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2)
                    ));
            }
            if (!reader.IsClosed) reader.Close();
            return categories;
        }
    }
}