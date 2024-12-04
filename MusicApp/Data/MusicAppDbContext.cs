using Microsoft.EntityFrameworkCore;

namespace MusicApp.Data
{
    public class MusicAppDbContext: DbContext
    {
        public MusicAppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
