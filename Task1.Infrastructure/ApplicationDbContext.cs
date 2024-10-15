using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Task1.Core.Entities;


namespace Task1.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the ClientClass enum to be stored as a string
            modelBuilder.Entity<Client>()
                .Property(c => c.Class)
                .HasConversion<string>();

            // Configure the ClientState enum to be stored as a string
            modelBuilder.Entity<Client>()
                .Property(c => c.State)
                .HasConversion<string>();
        }
    }
}
