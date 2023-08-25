using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.DataAccess
{
    public class AppDbContext : DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext>  opt) : base(opt) { 

        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<CoverType> CoverTypes { get; set; } 
        public DbSet<Product> Products { get; set; }


         
    }
}
