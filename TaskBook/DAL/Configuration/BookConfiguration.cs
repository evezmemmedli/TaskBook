using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBook.Models;

namespace TaskBook.DAL.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.Name).HasMaxLength(20);
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(9,2)");
            builder.Property(b => b.Page).IsRequired().HasMaxLength(700);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(20);

        }
    }
}
