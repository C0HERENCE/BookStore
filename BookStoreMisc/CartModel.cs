using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class CartModel
    {
        public List<BookOrderModel> book = new List<BookOrderModel>();
        public UserInfoModel user = new UserInfoModel();
    }
}