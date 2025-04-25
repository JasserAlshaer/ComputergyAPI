using ComputergyAPI.Entites;
using Microsoft.EntityFrameworkCore;

namespace ComputergyAPI.Contexts
{
    //1- Inherante From DbContext Class
    //2- Call base Constrcator with DbContextOptionsParameter 
    //3- override onCreatingModel Method
    //4- configure connection string on program.cs
    public class ComputergyDbContext : DbContext
    {
        public ComputergyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; } // configure - mark person class as table in database
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
