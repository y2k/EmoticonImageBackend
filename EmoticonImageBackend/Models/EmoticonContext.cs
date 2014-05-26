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

        public DbSet<Picture> Pictures { get; set; }

        public class Emoticon
        {
            public int Id { get; set; }
            public int PictureId { get; set; }
        }

        public class Picture
        {
            public int Id { get; set; }
        }
    }
}