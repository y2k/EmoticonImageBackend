using System.Data.Entity;

namespace EmoticonImageService.Models
{
    public class EmoticonContext : DbContext
    {
        public EmoticonContext() : base("Server=(localdb)\\mssqllocaldb;Database=EmoticonImageService-79c2bba9-4caf-497d-9dba-32579bf3bca0;Trusted_Connection=True;MultipleActiveResultSets=true") { }

        public DbSet<Emoticon> Emoticons { get; set; }

        public class Emoticon
        {
            public int Id { get; set; }

            public string ImageId { get; set; }

            public string Description { get; set; }
        }
    }
}