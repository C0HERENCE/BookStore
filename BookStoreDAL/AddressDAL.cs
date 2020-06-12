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
            string sql = "select * from Address where user_id = @id and enabled = 1";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static int InsertAddress(AddressModel address)
        {
            string sql = "insert into address values (@tel,@add,@name,@user_id,1,@isdefault)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("tel",address.tel),
                new SqlParameter("add",address.add),
                new SqlParameter("name",address.name),
                new SqlParameter("user_id",address.user_id),
                new SqlParameter("isdefault",address.isdefault)
            });
        }

        public static int SelectAddressCountByUserID(int id)
        {
            string sql = "select Count(*) from Address where user_id = @id and enabled = 1";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static int UpdateDefaultAddress(int id)
        {
            string sql = "update address set [default]=1 where id=@id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });

        }

        public static int UpdateAddress(AddressModel addressModel)
        {
            string sql = "update address set tel=@tel,[add]=@add,[name]=@name where id =@id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("tel",addressModel.tel),
                new SqlParameter("add",addressModel.add),
                new SqlParameter("name",addressModel.name),
                new SqlParameter("id",addressModel.id)
            });
        }

        public static int UpdateAddressEnabled(int id)
        {
            string sql = "update address set enabled=0 where id =@id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static SqlDataReader SelectDefaultAddress(int userID)
        {
            string sql = "select * from address where user_id=@userid and [enabled]=1 and [default]=1";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("userid",userID)
            });
        }
    }
}