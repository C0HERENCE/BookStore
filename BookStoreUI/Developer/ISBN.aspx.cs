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
using System.Threading;

namespace ppll
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //System.Data.DataTable dt = new System.Data.DataTable();
                //dt = SqlHelper.ExecuteDataTable("select * from category where role=0", null);
                //DropDownList1.DataSource = dt;
                //DropDownList1.DataTextField = "name";
                //DropDownList1.DataValueField = "id";
                //DropDownList1.DataBind();
                //DropDownList1_SelectedIndexChanged(null, null);
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
            public int u;
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
            webRequest.Timeout = 13000;//3秒超时
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
            try
            {
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
            }
            catch (Exception e3)
            {
                string a = e3.Message;
            }
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
            StreamReader streamReader = new StreamReader( Server.MapPath("~/Developer/cate3.txt"));
            
            string line = streamReader.ReadLine();
            line = line.Trim();
            string categoryname = "";
            int categorynameid = 0;
            string isbnname = "";
            while (!string.IsNullOrEmpty(line))
            {
                StreamWriter sw = new StreamWriter("C: \\Users\\Yang\\Desktop\\ans.txt", true);
                if (line.Trim().Length != 13)
                {
                    sw.WriteLine(categoryname);
                }
                else
                {
                    isbnname = line;
                    all aa = new all();
                    string bookapi = @"http://api.xiaomafeixiang.com/api/bookinfo";
                    string urlHandler = bookapi + "?isbn=" + isbnname;
                    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(urlHandler);
                    webRequest.Timeout = 5000;
                    StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                    string result = responseReader.ReadToEnd();
                    aa = JsonConvert.DeserializeObject<all>(result);

                    sw.Write(result);
                    sw.Write("\n");
                }
                sw.Close();
                line = streamReader.ReadLine();
                line = line.Trim();
                Thread.Sleep(1000);
            }
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
        protected void aaa()
        {
            StreamReader streamReader = new StreamReader("C: \\Users\\Yang\\Desktop\\ans.txt");
            string line = null;
            List<all> alls = new List<all>();
            while ((line=streamReader.ReadLine())!=null)
            {
                if (line=="")
                {
                    continue;
                }
                all bb = (all)JsonConvert.DeserializeObject(line,typeof(all));
                if (bb.msg== "获取图书数据成功")
                {
                    alls.Add(bb);
                }
            }
            foreach (all aa in alls)
            {
                if ((int)SqlHelper.ExecuteScalar("select count(*) from bookinfo where isbn = @isbn", new SqlParameter[1] { new SqlParameter("isbn", aa.data.isbn) }) >= 1)
                    continue;
                if (aa.data.summary.Length > 3500) aa.data.summary = aa.data.summary.Substring(0, 3500);
                if (aa.data.catalog.Length > 3500) aa.data.catalog = aa.data.catalog.Substring(0, 3500);
                if (aa.data.author_intro.Length > 3500) aa.data.author_intro = aa.data.author_intro.Substring(0, 3500);
                if ((int)SqlHelper.ExecuteScalar("select count(*) from publisher where name = @publisher", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) }) < 1)
                    SqlHelper.ExecuteNonQuery("insert into publisher values (@publisher)", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) });
                int publisherid = (int)SqlHelper.ExecuteScalar("select id from publisher where name = @publisher", new SqlParameter[1] { new SqlParameter("publisher", aa.data.publisher) });
                if ((int)SqlHelper.ExecuteScalar("select count(*) from author where name = @author", new SqlParameter[1] { new SqlParameter("author", aa.data.author) }) < 1)
                    SqlHelper.ExecuteNonQuery("insert into author values (@author,@authorintro)", new SqlParameter[2] { new SqlParameter("author", aa.data.author), new SqlParameter("authorintro", aa.data.author_intro) });
                int authorid = (int)SqlHelper.ExecuteScalar("select id from author where name = @author", new SqlParameter[] { new SqlParameter("author", aa.data.author) });
                try
                {
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
                }
                catch (Exception e3)
                {
                    string a = e3.Message;
                }
                try
                {
                    int bookid = (int)SqlHelper.ExecuteScalar("select id from bookinfo where isbn = @isbn", new SqlParameter[] { new SqlParameter("isbn", aa.data.isbn) });

                    if (aa.data.tags.Contains(";"))
                    {
                        foreach (string item in aa.data.tags.Split(';'))
                        {
                            if (item.Length < 1) continue;
                            string tag = item.Trim();
                            int tagid = 0;
                            if ((int)SqlHelper.ExecuteScalar("select count(*) from tag where name = @tag", new SqlParameter[1] { new SqlParameter("tag", tag) }) < 1)
                                SqlHelper.ExecuteNonQuery("insert into tag values (@tag)", new SqlParameter[] { new SqlParameter("tag", tag) });
                            tagid = (int)SqlHelper.ExecuteScalar("select id from tag where name = @tag", new SqlParameter[] { new SqlParameter("tag", tag) });
                            SqlHelper.ExecuteNonQuery("insert into bookinfo_tag values(@bookid,@tagid)", new SqlParameter[2] { new SqlParameter("bookid", bookid), new SqlParameter("tagid", tagid) });
                        }
                    }
                    else
                    {
                        foreach (string item in aa.data.tags.Split('>'))
                        {
                            if (item.Length < 1) continue;
                            string tag = item.Substring(1).Trim();
                            int tagid = 0;
                            if ((int)SqlHelper.ExecuteScalar("select count(*) from tag where name = @tag", new SqlParameter[1] { new SqlParameter("tag", tag) }) < 1)
                                SqlHelper.ExecuteNonQuery("insert into tag values (@tag)", new SqlParameter[] { new SqlParameter("tag", tag) });
                            tagid = (int)SqlHelper.ExecuteScalar("select id from tag where name = @tag", new SqlParameter[] { new SqlParameter("tag", tag) });
                            SqlHelper.ExecuteNonQuery("insert into bookinfo_tag values(@bookid,@tagid)", new SqlParameter[2] { new SqlParameter("bookid", bookid), new SqlParameter("tagid", tagid) });
                        }
                    }
                }
                catch (Exception xx)
                {
                    string ssb = xx.Message;
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sb = "\nhttps://img3.doubanio.com/view/subject/m/public/s29053580.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1103152.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1070959.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6384944.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1070222.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1144911.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1078958.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1727290.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28357056.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26601790.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1146040.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1066570.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1015872.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s3984108.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3563113.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2280094.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1151479.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27943411.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1447349.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1201610.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2393243.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s4661043.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s24468373.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s33318198.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26543835.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s2654869.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1670642.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6828981.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29593746.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6343233.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s24514468.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29651121.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27264181.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s11284102.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3254244.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1044902.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1979223.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1067491.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27313674.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s10458247.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3381125.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s11168631.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29593012.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29872681.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1311084.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2128420.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27080623.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s25996945.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s33462098.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1430717.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3122713.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27999290.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29609541.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s5765615.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s9130587.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28280241.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s5662327.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s9012759.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s2142329.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s32324813.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s6040237.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2636351.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1011204.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3380714.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1790771.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1102803.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1076372.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1466042.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4045138.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29683411.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6478105.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1073110.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1456781.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s9853099.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26384792.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1120437.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2019056.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s2414747.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s32322906.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28041509.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29827188.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s10585083.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29539252.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1083972.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s23414121.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4550508.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s9077296.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s32312678.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6862023.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29331058.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s24933076.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29247343.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27762150.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27435757.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33489085.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27792790.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29520436.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s24492121.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s4608182.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s33438927.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s10909903.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26262254.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29051384.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3003932.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33489470.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28076033.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33438650.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s33503357.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2566102.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1679084.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s2857766.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3030362.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s8972088.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28522258.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s29494856.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s24598159.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s3637818.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4552058.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33300502.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28789195.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s4066986.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s6643217.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28354107.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29498931.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s26262207.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29749429.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26686403.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33442245.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29855169.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29868391.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28094117.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27997234.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28375919.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28423584.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29276317.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28944485.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28328599.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27181129.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27274391.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28909494.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1436312.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27211529.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1804710.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s32333998.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2174222.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29846566.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28299560.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s29634396.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3010562.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28045305.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1557610.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2976745.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29821845.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s9108552.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28561075.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1483347.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29049325.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s4437626.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s5107054.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28290375.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s33492346.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s24561045.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27466554.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33475945.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27256934.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29500596.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s30021356.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3474155.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s2009787.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29857354.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27035914.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3237601.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27354371.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1817185.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33307011.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27905689.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s9003954.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s24517058.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27971771.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29663281.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s3799757.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28336411.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28110856.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27528977.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3694090.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29661387.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3601422.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s32265090.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s28344007.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28299141.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6193530.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s33457058.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s32270044.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4701908.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28316921.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27677959.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1114142.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29533231.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s26590200.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6918785.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29733058.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s26914079.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2861552.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s6738709.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3749515.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1447972.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s10431840.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s29440008.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s1057759.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s6807265.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1035374.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29963833.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1989131.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s3129915.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4532008.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s2006174.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28040043.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27258139.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s1914742.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29923715.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s28453934.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s33445061.jpg\nhttps://img9.doubanio.com/view/subject/m/public/s2905586.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s29382914.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s24574862.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s4379914.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s27243455.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s4592217.jpg\nhttps://img3.doubanio.com/view/subject/m/public/s32299271.jpg\nhttps://img1.doubanio.com/view/subject/m/public/s27237628.jpg";
            StreamReader streamReader = new StreamReader("C: \\Users\\Yang\\Desktop\\ans.txt");
            string line = null;
            List<all> alls = new List<all>();
            int ac = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Length<3)
                {
                    ac = int.Parse(line);
                    continue;
                }
                all bb = (all)JsonConvert.DeserializeObject(line, typeof(all));

                if (bb.msg == "获取图书数据成功")
                {
                    bb.data.u = ac;
                    alls.Add(bb);
                }
            }
            streamReader.Close();
            foreach (all a in alls)
            {
                int isbncount = (int)SqlHelper.ExecuteScalar("select count(*) from bookinfo where isbn=" + a.data.isbn,null);
                if (isbncount>00)
                {
                    continue;
                }
                int authorid = BookStoreBLL.AuthorBLL.GetAuthorIDByname(a.data.author);
                if (authorid==-1)
                {
                    BookStoreMisc.AuthorModel author = new BookStoreMisc.AuthorModel(a.data.author, a.data.author_intro);
                    if (author.intro.Length>3000)
                    {
                        author.intro = author.intro.Substring(0, 2500);
                    }
                    BookStoreBLL.AuthorBLL.AddAuthor(author);
                    authorid = BookStoreBLL.AuthorBLL.GetAuthorIDByname(a.data.author);
                }
                int publisherid = BookStoreBLL.AuthorBLL.GetAuthorIDByname(a.data.publisher);
                if (publisherid == -1)
                {
                    BookStoreMisc.PublisherModel publisher = new BookStoreMisc.PublisherModel(a.data.publisher);
                    BookStoreBLL.PublisherBLL.AddPublisher(publisher);
                    publisherid = BookStoreBLL.AuthorBLL.GetAuthorIDByname(a.data.author);
                }
                BookStoreMisc.BookInfoModel book = new BookStoreMisc.BookInfoModel();
                book.author_id = authorid;
                book.catalog = a.data.catalog;
                book.category_id = a.data.u;
                book.image = a.data.image;
                book.isbn = a.data.isbn;
                book.origintitle = a.data.origintitle;
                book.pages = a.data.pages;
                book.price = a.data.price;
                book.publisher_id = publisherid;
                book.pubdate = a.data.pubdate;
                book.subtitle = a.data.subtitle;
                book.summary = a.data.summary;
                book.title = a.data.title;
                try
                {

                    if (book.summary.Length > 3000)
                    {
                        book.summary = book.summary.Substring(0, 2500);
                    }
                    if (book.catalog.Length > 3000)
                    {
                        book.catalog = book.catalog.Substring(0, 2500);
                    }
                }
                catch (Exception xx)
                {
                    string ss = xx.Message;
                    throw;
                }
                BookStoreBLL.BookInfoBLL.AddBook(book);
            }
        }
    }
}