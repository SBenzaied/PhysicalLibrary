using Microsoft.EntityFrameworkCore;
using PhysicalLibrary.Books;
using PhysicalLibrary.Loans;
using PhysicalLibrary.Members;

namespace PhysicalLibrary.Data
{
    public class PhysicalLibraryDbContext : DbContext
    {
        public PhysicalLibraryDbContext(DbContextOptions<PhysicalLibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title).HasMaxLength(200);
                entity.Property(b => b.Author).HasMaxLength(200);
                entity.Property(b => b.Isbn).HasMaxLength(20);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(m => m.LastName).HasMaxLength(200);
                entity.Property(m => m.FirstName).HasMaxLength(200);
                entity.Property(m => m.Email).HasMaxLength(200);
                entity.HasIndex(m => m.Email).IsUnique();
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne<Member>().WithMany().HasForeignKey(m => m.MemberId);
                entity.HasOne<Book>().WithMany().HasForeignKey(m => m.BookId);
            });
        }
    }
}
