using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
        public DbSet<Category> Categories {get; set;}
}