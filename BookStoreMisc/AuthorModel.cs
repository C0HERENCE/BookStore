using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class AuthorModel
    {
        public int id;
        public string name;
        public string intro;

        public AuthorModel(string name, string intro)
        {
            this.name = name;
            this.intro = intro;
        }

        public AuthorModel()
        {
        }
    }
}