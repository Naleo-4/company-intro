using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models.Models;

namespace Project.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,  ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Update(category);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
