using StoreYourVideo.Models;

namespace StoreYourVideo.data
{
    public class DBContextVideos : DbContext
    {
        public DBContextVideos(DbContextOptions<DBContextVideos> options) : base(options)  { }
        public DbSet<User> users { get; set; }
        public DbSet<Video> videos { get; set; }
    }
}
