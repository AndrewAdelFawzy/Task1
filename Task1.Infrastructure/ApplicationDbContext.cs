using Microsoft.EntityFrameworkCore;
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
            // Configure unique constraint for Client Code
            //modelBuilder.Entity<Client>()
            //    .HasIndex(c => c.Code)
            //    .IsUnique();

            //base.OnModelCreating(builder);
        }
    }
}
