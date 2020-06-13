using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class BookOrderModel
    {
        public BookStatModel book = new BookStatModel();
        public int quantity = 0;
        public double price = 0;
        public int enabled = 1;
    }
}