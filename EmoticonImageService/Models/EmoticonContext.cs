using System.Data.Entity;
using System.Data.SQLite;

namespace EmoticonImageService.Models
{
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            //SQLiteProviderFactory f = System.Data.SQLite.EF6.SQLiteProviderFactory.Instance;

            SetProviderFactory("System.Data.SQLite.EF6", new System.Data.SQLite.EF6.SQLiteProviderFactory());
        }
    }

    [DbConfigurationType(typeof(MyConfiguration))]
    public class EmoticonContext : DbContext
    {
        //public EmoticonContext() : base("Server=(localdb)\\mssqllocaldb;Database=EmoticonImageService-79c2bba9-4caf-497d-9dba-32579bf3bca0;Trusted_Connection=True;MultipleActiveResultSets=true") { }

        public EmoticonContext() : base(new SQLiteConnection("Data Source=mydb.db;Version=3;"), true) {
        }

        public DbSet<Emoticon> Emoticons { get; set; }

        public class Emoticon
        {
            public int Id { get; set; }

            public string ImageId { get; set; }

            public string Description { get; set; }
        }
    }
}