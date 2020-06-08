using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class CategoryModel
    {
        public int id = 0;
        public int role = 0;
        public string name = "";

        public CategoryModel()
        {
        }

        public CategoryModel(int id, string name, int role)
        {
            this.id = id;
            this.role = role;
            this.name = name;
        }
    }
}