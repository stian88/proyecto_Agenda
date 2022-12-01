using Microsoft.EntityFrameworkCore;


namespace Agenda.Models
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 
        
        }
         
        public DbSet<Contactos> Contactos { get; set; }    
    }

}
