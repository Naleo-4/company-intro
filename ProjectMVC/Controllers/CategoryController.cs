using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Data;
using Project.DataAccess.Repository;
using Project.DataAccess.Repository.IRepository;
using Project.Models.Models;

namespace ProjectMVC.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Category> CategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
        return View(CategoryList);
    }
    //Get
    public IActionResult Create()
    {
        return View();
    }
    //POST
    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category Added Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(category);
    }

    //Get
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Category? category = _unitOfWork.CategoryRepository.Get(c => c.ID == id);
        // Category? categoryFromDBFirst = UnitOfWork..Categories.FirstOrDefault(c => c.ID == id);
        // Category? categoryFromDBSingle = UnitOfWork..Categories.SingleOrDefault(c => c.ID == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }
    //POST
    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(category);
    }

    //Get
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var category = _unitOfWork.CategoryRepository.Get(c => c.ID == id);
        // var categoryFromDBFirst = UnitOfWork..Categories.FirstOrDefault(c => c.ID == id);
        // var categoryFromDBSingle = UnitOfWork..Categories.SingleOrDefault(c => c.ID == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }
    //POST
    [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var category = _unitOfWork.CategoryRepository.Get(c => c.ID == id);
        if (category == null)
        {
            return NotFound();
        }
        _unitOfWork.CategoryRepository.Remove(category);
        _unitOfWork.Save();
        TempData["Success"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
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