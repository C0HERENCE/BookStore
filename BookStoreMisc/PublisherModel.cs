using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class PublisherModel
    {
        public int id;
        public string name;

        public PublisherModel(string name)
        {
            this.name = name;
        }

        public PublisherModel()
        {
        }
    }
}