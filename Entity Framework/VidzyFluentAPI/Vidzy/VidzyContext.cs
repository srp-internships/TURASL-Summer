using System.Data.Entity;
using Vidzy.EntityConfigurations;

namespace Vidzy
{
    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }    
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfigurations());
            modelBuilder.Configurations.Add(new GenreConfigurations());
        }
    }
}