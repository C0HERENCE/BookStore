using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.Dashboard.api
{
    /// <summary>
    /// Summary description for getallpublisher
    /// </summary>
    public class getallpublisher : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write(BookStoreBLL.PublisherBLL.GetAllPublisher());
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