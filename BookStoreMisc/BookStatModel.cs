using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class BookStatModel
    {
        public int id;
        public int stock;
        public float price;
        public bool onsale;

        public BookStatModel()
        {
        }

        public BookStatModel(int id, int stock, float price, bool onsale)
        {
            this.id = id;
            this.stock = stock;
            this.price = price;
            this.onsale = onsale;
        }
    }

}