using Microsoft.EntityFrameworkCore;
using URLShortener.DAL.DbDataGenerators;
using URLShortener.DAL.Entities;
using URLShortener.DAL.EntitiesConfiguration;

namespace URLShortener.DAL.Context
{
    public class URLShortenerDbContext : DbContext
    {
        public URLShortenerDbContext(DbContextOptions<URLShortenerDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<UrlAdress> UrlAdresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UrlAdressConfiguration());

            base.OnModelCreating(modelBuilder);

            UserDataGenerator.Generate(modelBuilder);
            UrlAdressDataGenerator.Generate(modelBuilder);
        }
    }
}
