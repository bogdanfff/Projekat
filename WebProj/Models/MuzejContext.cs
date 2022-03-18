using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MuzejContext : DbContext
    {
        public DbSet<Muzej> Muzej {get; set;}
        public DbSet<Karta> Karta {get; set;}
        public DbSet<Predmet> Predmet {get; set;}

        public MuzejContext(DbContextOptions options) : base(options)
        {
        }
        

          

        
    }
        
}
