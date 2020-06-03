using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreBLL;
using System.Web.SessionState;

namespace BookStore.API
{
    /// <summary>
    /// Summary description for BatchEditBook
    /// </summary>
    public class BatchEditBook : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            if (context.Session["isadmin"] != null && (bool)context.Session["isadmin"] == true)
            {
                string a = context.Request["type"];
                if (context.Request["type"] != null)
                {
                    if (context.Request["type"] == "del" && context.Request["bookid[]"] != null && context.Request["delnew"] != null)
                    {
                        string[] strs = context.Request["bookid[]"].Split(',');
                        int newdel = int.Parse(context.Request["delnew"]);
                        int[] ids = new int[strs.Length];
                        for (int i = 0; i < strs.Length; i++)
                        {
                            ids[i] = int.Parse(strs[i]);
                        }
                        context.Response.Write(BookBLL.BatchDelBook(ids, newdel));
                        return;
                    }
                }
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