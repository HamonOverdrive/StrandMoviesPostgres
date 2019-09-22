
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieList> MovieLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one-to-many relationship with users to movieslists
            modelBuilder.Entity<User>()
                .HasMany(c => c.MovieLists)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Cascade);


            // one-to-many relationship with movielist to movies
            modelBuilder.Entity<MovieList>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.MovieList)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
