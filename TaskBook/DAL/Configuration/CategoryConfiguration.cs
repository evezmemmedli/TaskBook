using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBook.Models;

namespace TaskBook.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.HasIndex(c=>c.Name).IsUnique();
        }
    }
}
