using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using BookStoreDAL;

namespace BookStoreBLL
{
    public class OrderBLL
    {
        public static OrderModel GetOrderByID(int id)
        {
            OrderModel order = new OrderModel();
            var reader = OrderDAL.SelectOrderByID(id);
            if (reader == null) return new OrderModel();
            reader.Read();
            order.id = reader.GetInt32(0);
            int userid = reader.GetInt32(1);
            order.dateTime = reader.GetDateTime(2);
            order.totalPrice = reader.GetDouble(3);
            order.comment = reader.GetString(4);
            order.status = reader.GetInt32(5);
            int addressid = reader.GetInt32(6);
            order.user = UserInfoBLL.GetUserInfoByID(userid);
            order.address = AddressBLL.GetAddressByID(addressid);
            order.books = new List<BookOrderModel>();
            reader = OrderDAL.SelectOrderBooksByID(id);
            while (reader.Read())
            {
                BookOrderModel bookOrder = new BookOrderModel();
                bookOrder.book = BookStatBLL.GetBookByID(reader.GetInt32(0));
                bookOrder.amount = reader.GetInt32(2);
                bookOrder.price = reader.GetDouble(3);
                order.books.Add(bookOrder);
            }
            return order;
        }

        public static string AddOrder(OrderModel order)
        {
            if (OrderDAL.InsertOrder(order)==1)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }
    }
}