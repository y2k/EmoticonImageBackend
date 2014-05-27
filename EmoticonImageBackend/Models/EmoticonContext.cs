using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmoticonImageBackend.Models
{
    public class EmoticonContext : DbContext
    {
        public EmoticonContext() : base("name=EmoticonContext") { }

        public DbSet<Emoticon> Emoticons { get; set; }

        public class Emoticon
        {
            public int Id { get; set; }

            public string ImageId { get; set; }

            public string Description { get; set; }
        }
    }
}