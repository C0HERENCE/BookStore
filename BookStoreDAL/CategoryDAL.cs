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
        public static SqlDataReader SelectCategoryByRole(int role)
        {
            return SqlHelper.ExecuteDataReader(
                "select * from category where role=@role",
                new SqlParameter[] { new SqlParameter("role", role) }
                );
        }

        public static int SelectCategoryParent(int id)
        {
            return (int)SqlHelper.ExecuteScalar(
                "select role from category where id=@id",
                new SqlParameter[] { new SqlParameter("id", id) }
                );
        }
    }
}