using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreBLL;
using System.Web.SessionState;

namespace BookStore.API
{
    /// <summary>
    /// Summary description for DelBook
    /// </summary>
    public class DelBook : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            if (context.Session["isadmin"] != null && (bool)context.Session["isadmin"] == true)
            {
                int bookid = -1;
                int delnew = -1;
                if (context.Request["bookid"]!=null && context.Request["delnew"]!=null)
                {
                    bookid = int.Parse(context.Request["bookid"]);
                    delnew = int.Parse(context.Request["delnew"]);
                }
                context.Response.Write(BookInfoBLL.DelBook(bookid, delnew));
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