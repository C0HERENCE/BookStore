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
            string sql = "select * from bookinfo_order where order_id = @id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[] {
                new SqlParameter("id",id)
            });
        }
        public static int SelectOrderBookCount(BookOrderModel bookOrder, OrderModel order)
        {
            string sql = "select count(*) from bookinfo_order where order_id=@orderid and book_id=@bookid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("orderid",order.id),
                new SqlParameter("bookid",bookOrder.book.id)
            });
        }
        public static int InsertOrderBook(BookOrderModel bookOrder, OrderModel order)
        {
            string sql2 = "insert into bookinfo_order values (@bookid,@order_id,@amount,@price)";
            return SqlHelper.ExecuteNonQuery(sql2, new SqlParameter[] {
                    new SqlParameter("bookid",bookOrder.book.id),
                    new SqlParameter("order_id",order.id),
                    new SqlParameter("amount",bookOrder.amount),
                    new SqlParameter("price",bookOrder.price)
                });
        }

        public static int UpdateOrderBook(BookOrderModel bookOrder,OrderModel order)
        {
            string sql = "update bookinfo_order set amount = @newvalue where order_id=@orderid and book_id=@bookid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("newvalue",bookOrder.amount),
                new SqlParameter("orderid",order.id),
                new SqlParameter("bookid",bookOrder.book.id)
                });
        }

        public static int UpdateOrderTotalPrice(OrderModel order, double newvalue)
        {
            string sql = "update [order] set price = @newvalue where id = @orderid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("newvalue",newvalue),
                new SqlParameter("orderid",order.id)
            });
        }

        public static int UpdateOrderAddress(int orderid, int addressid)
        {
            string sql = "update [order] set address_id = @addressid where id = @orderid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("addressid",addressid),
                new SqlParameter("orderid",orderid)
            });
        }

        public static SqlDataReader SelectOrderIDByUserID(int id)
        {
            string sql = "select id from [order] where user_id=@id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[]
            {
                new SqlParameter("id",id)
            });
        }

        public static int UpdateOrderStatus(int orderid, OrderStatus status)
        {
            string sql = "update [order] set status = @status where id = @orderid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("status",(int)status),
                new SqlParameter("orderid",orderid)
            });
        }

        public static int UpdateOrderComment(int orderid, string comment)
        {
            string sql = "update [order] set comment = @comment where id = @orderid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("comment",comment),
                new SqlParameter("orderid",orderid)
            });
        }

        public static int InsertOrder(OrderModel order)
        {
            string sql1 = "insert into [order] values(@userid,getdate(),@price,@comment,0,@address_id);Select @@Identity";
            Decimal reader = (decimal)SqlHelper.ExecuteScalar(sql1, new SqlParameter[] {
                new SqlParameter("userid",order.user.id),
                new SqlParameter("price",order.totalPrice),
                new SqlParameter("comment",order.comment),
                new SqlParameter("address_id",order.address.id)
            });
            order.id = Decimal.ToInt32(reader);
            foreach (BookOrderModel bookOrder in order.books)
            {
                int ret = InsertOrderBook(bookOrder, order);
                if (ret == 0) return -1;
            }
            return order.id;
        }
    }
}