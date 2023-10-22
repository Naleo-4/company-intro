using Microsoft.AspNetCore.Mvc;
using Project.Models.Models;
using Project.DataAccess.Repository.IRepository;
namespace ProjectMVC.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALL
        [HttpGet]
        public IActionResult GetAllNews()
        {
            List<News> NewsList = _unitOfWork.NewsRepository.GetAll().ToList();
            return Json(new { data = _unitOfWork.NewsRepository.GetAll() });
        }
        #endregion
    }
}
