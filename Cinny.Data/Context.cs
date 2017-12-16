using System.Data.Entity;
using Cinny.Data.Models;

namespace Cinny.Data
{
    public class Context: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviePlanned> MoviesPlanned { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowPlanned> ShowsPlanned { get; set; }

        public Context() : base("CinnyDemoDatabase")
        {

        }
    }
}
