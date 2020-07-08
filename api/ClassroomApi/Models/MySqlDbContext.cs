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
            Database.EnsureCreated();
        }

        static MySqlDbContext()
        {
            System.Data.Entity.DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
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
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
