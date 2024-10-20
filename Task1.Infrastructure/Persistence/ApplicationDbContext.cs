﻿namespace Task1.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProducts> ClientProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // To make a compiste key
            modelBuilder.Entity<ClientProducts>().HasKey(e => new { e.ClientId, e.ProductId });

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
