using System.Data.Entity;
using WebApplication.DAL.Entities;
using WebApplication.DAL.EntityConfigurations;

namespace WebApplication.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PetConfiguration());
        }
    }
}