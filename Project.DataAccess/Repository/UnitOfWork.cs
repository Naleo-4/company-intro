using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository{ get; private set; }
        public INewsRepository NewsRepository{ get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            NewsRepository = new NewsRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
