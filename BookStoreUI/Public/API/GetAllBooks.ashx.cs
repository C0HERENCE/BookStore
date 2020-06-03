using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreBLL;
using System.Web.SessionState;

namespace BookStore.API
{
    /// <summary>
    /// Summary description for GetAllBooks
    /// </summary>
    public class GetAllBooks : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            if (context.Session["isadmin"] != null && (bool)context.Session["isadmin"] == true) 
            {
                int page = -1;
                int limit = -1;
                if (context.Request["page"] != null && context.Request["limit"] != null)
                {
                    page = int.Parse(context.Request["page"]);
                    limit = int.Parse(context.Request["limit"]);
                }
                context.Response.Write(BookBLL.GetAllBooks(page, limit));
                return;
            }
            context.Response.Write("null");
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