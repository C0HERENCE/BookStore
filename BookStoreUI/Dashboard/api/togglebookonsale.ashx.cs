using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreBLL;

namespace BookStoreUI.Dashboard.api
{
    /// <summary>
    /// Summary description for togglebookonsale
    /// </summary>
    public class togglebookonsale : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["id[]"] == null)
            {
                context.Response.Write("failed");
                return;
            }
            if (context.Request["onsale"] == null)
            {
                context.Response.Write("failed");
                return;
            }
            string[] id = context.Request["id[]"].Split(',');
            int onsale = int.Parse(context.Request["onsale"]);
            bool flag = true;
            List<int> failedid = new List<int>();
            for (int i = 0; i < id.Length; i++)
            {
                int s = int.Parse(id[i]);
                if (BookStatBLL.SetBookOnSale(s, onsale)=="失败")
                {
                    flag = false;
                    failedid.Add(i);
                }
            }
            if (flag)
            {
                context.Response.Write("id");
                for (int i = 0; i < failedid.Count; i++)
                {
                    context.Response.Write(failedid[i] + "\n");
                }
                context.Response.Write("修改失败");
            }
            else
            {
                context.Response.Write("修改成功");
            }
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