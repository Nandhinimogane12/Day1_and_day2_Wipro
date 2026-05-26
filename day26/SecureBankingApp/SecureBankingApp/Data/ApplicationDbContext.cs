using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureBankingApp.Models;

namespace SecureBankingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // User Story 2 ku BankAccount table
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // BankAccount config
            builder.Entity<BankAccount>(entity =>
            {
                // AccountNumber ah string ah vachu iruku - idha dhaan Always Encrypted pannuvom
                entity.Property(e => e.AccountNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.Balance)
                      .HasColumnType("decimal(18,2)");

                // User ku oru relationship - optional
                entity.HasOne<IdentityUser>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}