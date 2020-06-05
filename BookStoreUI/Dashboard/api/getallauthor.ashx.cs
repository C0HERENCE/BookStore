using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.Dashboard.api
{
    /// <summary>
    /// Summary description for getallauthor
    /// </summary>
    public class getallauthor : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write(BookStoreBLL.AuthorBLL.GetAllAuthor());
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