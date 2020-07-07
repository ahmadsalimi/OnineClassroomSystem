using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using MySql.Data.EntityFramework;

namespace ClassroomApi.Models
{
    
    [DbContext(typeof(MySqlEFConfiguration))]
    public class MySqlDbContext : DbContext
    {
        private readonly IConfiguration config;

        public MySqlDbContext(IConfiguration config)
        {
            this.config = config;
        }

        public DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(config.GetConnectionString("ClassroomApiContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.ClassName });
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.ClassName).IsRequired();
            });
        }
    }
}
