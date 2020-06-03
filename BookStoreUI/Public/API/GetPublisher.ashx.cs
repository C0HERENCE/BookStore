using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookStoreUI.Public.API
{
    /// <summary>
    /// Summary description for GetCategory
    /// </summary>
    public class GetPublisher : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            if (context.Session["isadmin"] != null && (bool)context.Session["isadmin"] == true)
            {
                int role = -1;
                if (context.Request["role"] != null)
                {
                    role = int.Parse(context.Request["role"]);
                }
                context.Response.Write(BookStoreBLL.CategoryBLL.GetCategory(role));
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