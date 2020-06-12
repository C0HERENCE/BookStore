using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    /// <summary>
    /// 1. 买家下单后：待付款
    /// 2. 买家付款后：待确认
    /// 3. 商家确认后：配送中
    /// 4. 买家确认后：已完成
    /// 5. 卖家付款时间过后：已过期
    /// 6. 买家主动取消： 已取消
    /// </summary>
    public enum OrderStatus
    {
        UnPaid = 0, // 待付款
        Process = 1, //待确认
        Dispatching = 2, // 配送中
        Complete = 3, // 已完成
        Cancel = 4, // 已取消
        Closed = 5, // 已过期
    }
    public class OrderModel
    {
        public int id = 0;
        public UserInfoModel user = new UserInfoModel();
        public AddressModel address;
        public List<BookOrderModel> books;
        public DateTime dateTime = DateTime.Now;
        public double totalPrice = 0;
        public string comment = "";
        public OrderStatus status = 0;

        public double CalculateTotalPrice()
        {
            totalPrice = 0;
            foreach (BookOrderModel bookOrder in books)
            {
                totalPrice += bookOrder.price*bookOrder.amount;
            }
            return totalPrice;
        }
        public string GetStatusString()
        {
            switch (status)
            {
                case OrderStatus.UnPaid:
                    return "未支付";
                case OrderStatus.Process:
                    return "待确认发货";
                case OrderStatus.Dispatching:
                    return "配送中";
                case OrderStatus.Complete:
                    return "已完成";
                case OrderStatus.Cancel:
                    return "已取消";
                case OrderStatus.Closed:
                    return "已过期";
                default:
                    return "未支付";
            }
        }

    }
}