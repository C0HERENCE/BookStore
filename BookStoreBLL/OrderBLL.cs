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
            order.status = (OrderStatus)reader.GetInt32(5);
            int addressid = reader.GetInt32(6);
            order.user = UserInfoBLL.GetUserInfoByID(userid);
            order.address = AddressBLL.GetAddressByID(addressid);
            order.books = new List<BookOrderModel>();
            if (!reader.IsClosed) reader.Close();
            reader = OrderDAL.SelectOrderBooksByID(id);
            while (reader.Read())
            {
                BookOrderModel bookOrder = new BookOrderModel();
                bookOrder.book = BookStatBLL.GetBookByID(reader.GetInt32(0));
                bookOrder.amount = reader.GetInt32(2);
                bookOrder.price = reader.GetDouble(3);
                order.books.Add(bookOrder);
            }
            if (!reader.IsClosed) reader.Close();
            return order;
        }

        public static int AddOrder(OrderModel order)
        {
            int orderid = OrderDAL.InsertOrder(order);
            if (orderid != -1)
            {
                return orderid;
            }
            else
            {
                return -1;
            }
        }

        public static int SetBookQuantity(BookOrderModel bookOrder, OrderModel order)
        {
            if (OrderDAL.SelectOrderBookCount(bookOrder, order) == 0)
            {
                return OrderDAL.InsertOrderBook(bookOrder, order);
            }
            else
            {
                return OrderDAL.UpdateOrderBook(bookOrder, order);
            }
        }

        public static int SetOrderTotalPrice(OrderModel order)
        {
            return OrderDAL.UpdateOrderTotalPrice(order, order.totalPrice);
        }

        public static int SetOrderAddress(int orderid, int addressid)
        {
            return OrderDAL.UpdateOrderAddress(orderid, addressid);
        }
        public static int SetOrderComment(int orderid, string comment)
        {
            return OrderDAL.UpdateOrderComment(orderid, comment);
        }
        public static int SetOrderStatus(int orderid, OrderStatus status)
        {
            return OrderDAL.UpdateOrderStatus(orderid, status);
        }

        public static List<OrderModel> GetOrdersByUserID(int id)
        {
            List<OrderModel> orders = new List<OrderModel>();
            var reader =  OrderDAL.SelectOrderIDByUserID(id);
            while(reader.Read())
            {
                OrderModel order = GetOrderByID(reader.GetInt32(0));
                orders.Add(order);
            }
            reader.Close();
            return orders;
        }
    }
}