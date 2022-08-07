using Microsoft.EntityFrameworkCore;
using TaskBook.DAL.Configuration;
using TaskBook.Models;

namespace TaskBook.DAL
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext>opt):base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category>Categorie { get; set; }
    }
}
