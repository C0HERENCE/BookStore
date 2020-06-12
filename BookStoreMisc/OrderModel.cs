using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class OrderModel
    {
        public int id = 0;
        public UserInfoModel user = new UserInfoModel();
        public AddressModel address;
        public List<BookOrderModel> books;
        public DateTime dateTime = DateTime.Now;
        public double totalPrice = 0;
        public string comment = "";
        public int status = 0;

        public void CalculateTotalPrice()
        {
            totalPrice = 0;
            foreach (BookOrderModel bookOrder in books)
            {
                totalPrice += bookOrder.price*bookOrder.amount;
            }
        }
    }
}