﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookStoreDAL
{
    public class CategoryDAL
    {
        public static SqlDataReader SelectCategoryByRole(int role)
        {
            return SqlHelper.ExecuteDataReader(
                "select id,name from category where role=@role",
                new SqlParameter[] { new SqlParameter("role", role) }
                );
        }
    }
}