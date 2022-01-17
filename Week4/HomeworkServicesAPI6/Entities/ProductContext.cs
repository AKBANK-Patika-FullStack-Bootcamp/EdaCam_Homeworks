using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class ProductContext:DbContext
    {
        protected readonly IConfiguration Configuration;
         
        public ProductContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = DESKTOP-T7UAG83\\SQLEXPRESS; Database = ProductDB; integrated security = True;");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Brand>().ToTable("Brand");
        }
             
    }
}