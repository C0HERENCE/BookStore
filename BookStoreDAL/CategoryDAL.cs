using System;
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
        public static DataTable GetCategoryRole(int role)
        {
            return SqlHelper.ExecuteDataTable(
                "select id,name from category where role=@role",
                new SqlParameter[] { new SqlParameter("role", role) }
                );
        }
    }
}