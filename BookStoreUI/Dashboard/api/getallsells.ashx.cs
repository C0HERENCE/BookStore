using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.Dashboard.api
{
    /// <summary>
    /// Summary description for getallsells
    /// </summary>
    public class getallsells : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write(BookStoreBLL.BookStatBLL.GetAllBooks());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}