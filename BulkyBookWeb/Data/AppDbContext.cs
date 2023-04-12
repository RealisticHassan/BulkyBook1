using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class AppDbContext : DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext>  opt) : base(opt) { 
       
             
        
        }

        public DbSet<Category> Categories { get; set; } 
         
    }
}
