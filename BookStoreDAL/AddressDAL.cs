using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookStoreMisc;

namespace BookStoreDAL
{
    public class AddressDAL
    {
        public static SqlDataReader SelectAddressByID(int id)
        {
            string sql = "select * from Address where id = @id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }
        public static SqlDataReader SelectAddressByUserID(int id)
        {
            string sql = "select * from Address where user_id = @id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static int InsertAddress(AddressModel address)
        {
            string sql = "insert into address values (@tel,@add,@name,@user_id)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("tel",address.tel),
                new SqlParameter("add",address.add),
                new SqlParameter("name",address.name),
                new SqlParameter("user_id",address.user_id)
            });
        }
    }
}