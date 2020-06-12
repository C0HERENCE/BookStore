using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookStoreMisc;

namespace BookStoreDAL
{
    public class OrderDAL
    {
        public static SqlDataReader SelectOrderByID(int id)
        {
            string sql = "select * from [order] where id = @id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static SqlDataReader SelectOrderBooksByID(int id)
        {
            string sql = "select * from bookinfo_order where id = @id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }

        public static int InsertOrder(OrderModel order)
        {
            var a1 = new SqlParameter("userid", order.user.id);
            var a2 = new SqlParameter("price", order.totalPrice);
            var a3 = new SqlParameter("comment", order.comment);
            var a4 = new SqlParameter("address_id", order.address.id);
            string sql1 = "insert into [order] values(@userid,getdate(),@price,@comment,0,@address_id);Select @@Identity";

            Decimal reader = (decimal)SqlHelper.ExecuteScalar(sql1, new SqlParameter[] {
                new SqlParameter("userid",order.user.id),
                new SqlParameter("price",order.totalPrice),
                new SqlParameter("comment",order.comment),
                new SqlParameter("address_id",order.address.id)
            });
            int orderid = Decimal.ToInt32(reader);
            foreach (BookOrderModel bookOrder in order.books)
            {
                string sql2 = "insert into bookinfo_order values (@bookid,@order_id,@amount,@price)";
                int ret = SqlHelper.ExecuteNonQuery(sql2, new SqlParameter[] {
                    new SqlParameter("bookid",bookOrder.book.id),
                    new SqlParameter("order_id",orderid),
                    new SqlParameter("amount",bookOrder.amount),
                    new SqlParameter("price",bookOrder.price)
                });
                if (ret == 0)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}