using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class BookInfoModel
    {
        public int id;
        public string isbn;
        public string title;
        public string origintitle;
        public string subtitle;
        public string image;
        public int author_id;
        public int publisher_id;
        public int category_id;
        public string pubdate;
        public string pages;
        public string price;
        public string summary;
        public string catalog;

        public BookInfoModel()
        {
        }

        public BookInfoModel(string isbn, string title, string origintitle, string subtitle, string image, int author_id, int publisher_id, int category_id, string pubdate, string pages, string price, string summary, string catalog)
        {
            this.isbn = isbn;
            this.title = title;
            this.origintitle = origintitle;
            this.subtitle = subtitle;
            this.image = image;
            this.author_id = author_id;
            this.publisher_id = publisher_id;
            this.category_id = category_id;
            this.pubdate = pubdate;
            this.pages = pages;
            this.price = price;
            this.summary = summary;
            this.catalog = catalog;
        }
    }
}