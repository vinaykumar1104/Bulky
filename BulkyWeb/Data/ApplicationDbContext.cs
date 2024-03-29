using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
       // If you want to create Column at Database u need to use Dbset And u need to pass Model then what name u need to give  for table
        public DbSet<Category> Categories { get; set; }
        
        // It is used to manually write values into the table by Onmodel creating which was already present in dbcontext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // By modelbuilder u can see the data from Category table
            //.HasData is used to add data to the column
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            
        }

    }
}
