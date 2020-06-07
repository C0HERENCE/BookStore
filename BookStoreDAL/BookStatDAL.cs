using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using System.Data.SqlClient;
using System.Data;

namespace BookStoreDAL
{
    public class BookStatDAL
    {
        public static int SelectBookOnSaleCount()
        {
            string sql = "select count(*) from bookstat_full where onsale=1;";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public static DataTable SelectAllBooks()
        {
            string sql = "select * from bookstat_full";
            return SqlHelper.ExecuteDataTable(sql);
        }

        public static int UpdateBookOnSale(int id,int onsale)
        {
            string sql = "update bookstat set onsale=@onsale where id=@id";
            return (int)SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]{
                new SqlParameter("onsale",onsale),
                new SqlParameter("id",id)
            });
        }
    }
}