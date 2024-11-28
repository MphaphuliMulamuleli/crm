using Microsoft.EntityFrameworkCore;
using CRM.Core.Entities;

namespace CRM.Infrastructure.Data
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Title> Titles { get; set; } = null!;
        public DbSet<ClientType> ClientTypes { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<ClientCredential> ClientCredentials { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<ClientCredential>()
                .HasIndex(cc => cc.Username)
                .IsUnique();
        }
    }
}