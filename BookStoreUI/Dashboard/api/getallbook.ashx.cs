using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.Dashboard.api
{
    /// <summary>
    /// Summary description for getallbook
    /// </summary>
    public class getallbook : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write(BookStoreBLL.BookInfoBLL.GetAllBook());
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
