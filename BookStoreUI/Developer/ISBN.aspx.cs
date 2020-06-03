using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ppll
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = SqlHelper.ExecuteDataTable("select * from category where role=0", null);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                DropDownList1_SelectedIndexChanged(null, null);
            }
        }
        int categoryid = 0;
        public class Data
        {
            public string isbn;
            public string title;
            public string subtitle;
            public string origintitle;
            public string image;
            public string author;
            public string translator;
            public string publisher;
            public string pubdate;
            public string tags;
            public string kaiben;
            public string zhizhang;
            public string binding;
            public string taozhuang;
            public string series;
            public string pages;
            public string price;
            public string author_intro;
            public string summary;
            public string catalog;
        }

        public class all
        {
            public bool status = false;
            public Data data = new Data();
            public string msg = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            all aa = new all();
            //ashx Url
            string bookapi = @"http://api.xiaomafeixiang.com/api/bookinfo";
            //加入参数，用于更新请求
            string urlHandler = bookapi + "?isbn=" + TextBox1.Text;
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(urlHandler);
            webRequest.Timeout = 3000;//3秒超时
            //调用ashx，并取值
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string result = responseReader.ReadToEnd();
            aa = JsonConvert.DeserializeObject<all>(result);
            if (aa.msg != "获取图书数据成功")
                return;
            TextBox2.Text = aa.data.title;
            TextBox3.Text = aa.data.subtitle;
            TextBox3.Text = aa.data.origintitle;
            TextBox13.Text = aa.data.image;
            TextBox4.Text = aa.data.author;
            TextBox5.Text = aa.data.publisher;
            TextBox6.Text = aa.data.pubdate;
            TextBox7.Text = aa.data.tags;
            TextBox8.Text = aa.data.pages;
            TextBox9.Text = aa.data.price;
            TextBox10.Text = aa.data.author;
            TextBox11.Text = aa.data.author_intro;
            TextBox12.Text = aa.data.summary;
            TextBox14.Text = aa.data.catalog;
            if (aa.msg != "获取图书数据成功")
                return;
            if ((int)SqlHelper.ExecuteScalar("select count(*) from bookinfo where isbn = @isbn", new SqlParameter[1] { new SqlParameter("isbn", aa.data.isbn) }) >= 1)
                return;
            if (aa.data.summary.Length > 3500) aa.data.summary = aa.data.summary.Substring(0, 3500);
            if (aa.data.catalog.Length > 3500) aa.data.catalog = aa.data.catalog.Substring(0, 3500);
            if (aa.data.author_intro.Length > 3500) aa.data.author_intro = aa.data.author_intro.Substring(0, 3500);
            if ((int)SqlHelper.ExecuteScalar("select count(*) from publisher where name = @publisher", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) }) < 1)
                SqlHelper.ExecuteNonQuery("insert into publisher values (@publisher)", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) });
            int publisherid = (int)SqlHelper.ExecuteScalar("select id from publisher where name = @publisher", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) });
            if ((int)SqlHelper.ExecuteScalar("select count(*) from author where name = @author", new SqlParameter[1] { new SqlParameter("author", aa.data.author) }) < 1)
                SqlHelper.ExecuteNonQuery("insert into author values (@author,@authorintro)", new SqlParameter[2] { new SqlParameter("author", aa.data.author), new SqlParameter("authorintro", aa.data.author_intro) });
            int authorid = (int)SqlHelper.ExecuteScalar("select id from author where name = @author", new SqlParameter[] { new SqlParameter("author", aa.data.author) });
            SqlHelper.ExecuteNonQuery("insert into bookinfo values(@isbn,@title,@origintitle,@subtitle,@image,@authorid,@categoryid,@publisherid,@pubdate,@pages,@price,@summary,@catalog)",
                new SqlParameter[]{
                    new SqlParameter("isbn",aa.data.isbn),
                    new SqlParameter("title",aa.data.title),
                    new SqlParameter("subtitle",aa.data.subtitle),
                    new SqlParameter("origintitle",aa.data.origintitle),
                    new SqlParameter("image",aa.data.image),
                    new SqlParameter("authorid",authorid),
                    new SqlParameter("categoryid",int.Parse(DropDownList2.SelectedValue)),
                    new SqlParameter("publisherid",publisherid),
                    new SqlParameter("pubdate",aa.data.pubdate),
                    new SqlParameter("pages",aa.data.pages),
                    new SqlParameter("price",aa.data.price),
                    new SqlParameter("summary",aa.data.summary),
                    new SqlParameter("catalog",aa.data.catalog),
                });
            int bookid = (int)SqlHelper.ExecuteScalar("select id from bookinfo where isbn = @isbn", new SqlParameter[1] { new SqlParameter("isbn", aa.data.isbn) });
            foreach (string item in aa.data.tags.Split('>'))
            {
                if (item.Length < 1) continue;
                string tag = item.Substring(1);
                int tagid = 0;
                if ((int)SqlHelper.ExecuteScalar("select count(*) from tag where name = @tag", new SqlParameter[1] { new SqlParameter("tag", tag) }) < 1)
                    SqlHelper.ExecuteNonQuery("insert into tag values (@tag)", new SqlParameter[] { new SqlParameter("tag", tag) });
                tagid = (int)SqlHelper.ExecuteScalar("select id from tag where name = @tag", new SqlParameter[] { new SqlParameter("tag", tag) });
                SqlHelper.ExecuteNonQuery("insert into bookinfo_tag values(@bookid,@tagid)", new SqlParameter[2] { new SqlParameter("bookid", bookid), new SqlParameter("tagid", tagid) });
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT DISTINCT id,title, origintitle, subtitle, image, publisher, isbn, tag=STUFF((SELECT ',' + tags FROM bookinfo_view as t where t.id=bookinfo_view.id FOR XML path('')),1,1,''), category, author, author_intro, pubdate, pages, price, summary, catalog FROM bookinfo_view";

            System.Data.DataTable ans = SqlHelper.ExecuteDataTable(sql, null);

            sql = @"select count(*) from ""userinfo""";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("name", "COHERENCE");
            sqlParameters[1] = new SqlParameter("pwd", BookStoreMisc.MD5Encrypt.GetMD5("123"));
            int a = (int)SqlHelper.ExecuteScalar(sql, sqlParameters);
            Response.Write(a);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = SqlHelper.ExecuteDataTable("select * from category where role=@id", new SqlParameter[] { new SqlParameter("id", DropDownList1.SelectedValue) });
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "name";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            categoryid = int.Parse(DropDownList2.SelectedValue);
            Label1.Text = categoryid.ToString();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryid = int.Parse(DropDownList2.SelectedValue);
            Label1.Text = categoryid.ToString();
        }
    }
}