using Microsoft.EntityFrameworkCore;
using Project.Models.Models;

namespace Project.DataAccess.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<News> News {get; set;}
}