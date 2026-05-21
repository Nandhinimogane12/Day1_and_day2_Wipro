using Microsoft.EntityFrameworkCore;
using LibraryCodeFirst.Models;

namespace LibraryCodeFirst.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Book Table Configuration
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookID);

                entity.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

                // Foreign Key: One Author has Many Books
                entity.HasOne(d => d.Author)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.AuthorID)
                   .OnDelete(DeleteBehavior.Cascade);

                // Many-to-Many: Books <-> Genres
                entity.HasMany(d => d.Genres)
                   .WithMany(p => p.Books)
                   .UsingEntity(j => j.ToTable("BookGenres"));
            });

            // 2. Author Table Configuration
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorID);

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            });

            // 3. Genre Table Configuration
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreID);

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            });
        }
    }
}