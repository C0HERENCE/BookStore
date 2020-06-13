using BookStoreDAL;
using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBLL
{
    public class CartBLL
    {
        public static int AddBookToCart(CartModel cart, BookOrderModel book)
        {
            int bookcount = CartDAL.SelectBookCountInCart(cart, book);
            if (bookcount > 0)
            {
                book.quantity += CartDAL.SelectBookQuantityInCart(cart, book);
                if (book.quantity > 99)
                {
                    book.quantity = 99;
                }
                return CartDAL.UpdateBookInCart(cart, book);
            }
            else
            {
                return CartDAL.InsertBookToCart(cart, book);
            }
        }

        public static CartModel GetUserCart(int userid)
        {
            CartModel cart = new CartModel();
            cart.user = UserInfoBLL.GetUserInfoByID(userid);
            var reader = CartDAL.SelectBooksInCart(userid);
            while (reader.Read())
            {
                BookOrderModel book = new BookOrderModel();
                book.book = BookStatBLL.GetBookByID(reader.GetInt32(0));
                book.enabled = 1;
                book.quantity = reader.GetInt32(1);
                cart.book.Add(book);
            }
            reader.Close();
            return cart;
        }

        public static int DeleteBook(int userid, int bookid)
        {
            return CartDAL.UpdateBookEnabledInCart(userid, bookid);
        }

        public static int SetBookCount(CartModel cart, BookOrderModel book)
        {
            if (book.quantity > 99)
            {
                book.quantity = 99;
            }
            else if (book.quantity < 1)
            {
                book.quantity = 1;
            }
            int bookcount = CartDAL.SelectBookCountInCart(cart, book);
            if (bookcount > 0)
            {
                return CartDAL.UpdateBookInCart(cart, book);
            }
            else
            {
                return CartDAL.InsertBookToCart(cart, book);
            }
        }
    }
}