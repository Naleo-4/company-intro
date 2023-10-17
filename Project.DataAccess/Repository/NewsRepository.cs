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
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private ApplicationDbContext _db;

        public NewsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(News news)
        {
            _db.News.Update(news);
        }
    }
}
