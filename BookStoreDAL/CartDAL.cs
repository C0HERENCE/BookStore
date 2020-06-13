using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookStoreDAL
{
    public class CartDAL
    {
        public static SqlDataReader SelectBooksInCart(int Userid)
        {
            string sql = "select book_id,quantity from bookinfo_cart where user_id=@userid and enabled=1";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[]
            {
                new SqlParameter("userid",Userid)
            });
        }
        public static int SelectBookCountInCart(CartModel cart, BookOrderModel book)
        {
            string sql = "select count(*) from bookinfo_cart where book_id = @bookid and user_id=@userid and enabled=1";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("bookid",book.book.id),
                new SqlParameter("userid",cart.user.id)
            });
        }

        public static int SelectBookQuantityInCart(CartModel cart, BookOrderModel book)
        {
            string sql = "select quantity from bookinfo_cart where book_id = @bookid and user_id=@userid and enabled=1";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("bookid",book.book.id),
                new SqlParameter("userid",cart.user.id)
            });
        }

        public static int UpdateBookInCart(CartModel cart, BookOrderModel book)
        {
            string sql = "update bookinfo_cart set quantity=@quantity where user_id=@userid and book_id = @bookid and enabled=1";
            return (int)SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("quantity", book.quantity),
                new SqlParameter("userid", cart.user.id),
                new SqlParameter("bookid", book.book.id)
            });
        }

        public static int InsertBookToCart(CartModel cart, BookOrderModel book)
        {
            string sql = "insert into bookinfo_cart values (@bookid,@userid,@quantity,1)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("bookid",book.book.id),
                new SqlParameter("userid",cart.user.id),
                new SqlParameter("quantity",book.quantity)
            });
        }

        public static int UpdateBookEnabledInCart(int userid,int id)
        {
            string sql = "update bookinfo_cart set enabled = 0 where user_id=@userid and enabled = 1 and book_id=@bookid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("bookid",id),
                new SqlParameter("userid",userid),
            });
        }
    }
}