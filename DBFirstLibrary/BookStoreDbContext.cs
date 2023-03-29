using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstLibrary;
/// <summary>
/// Created Using below in Package Manager Console
/// Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=BookStoreDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
/// </summary>
public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.AuthorId, "IX_Books_AuthorId");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
