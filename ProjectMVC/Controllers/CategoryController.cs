using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models.Models;

namespace ProjectMVC.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _CategoryRepos;
    public CategoryController(ICategoryRepository db)
    {
        _CategoryRepos = db;
    }
    public IActionResult Index()
    {
        List<Category> CategoryList = _CategoryRepos.GetAll().ToList();
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
            _CategoryRepos.Add(category);
            _CategoryRepos.Save();
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
        Category? category = _CategoryRepos.Get(c => c.ID == id);
        // Category? categoryFromDBFirst = _CategoryRepos.Categories.FirstOrDefault(c => c.ID == id);
        // Category? categoryFromDBSingle = _CategoryRepos.Categories.SingleOrDefault(c => c.ID == id);
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
            _CategoryRepos.Update(category);
            _CategoryRepos.Save();
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
        var category = _CategoryRepos.Get(c => c.ID == id);
        // var categoryFromDBFirst = _CategoryRepos.Categories.FirstOrDefault(c => c.ID == id);
        // var categoryFromDBSingle = _CategoryRepos.Categories.SingleOrDefault(c => c.ID == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }
    //POST
    [HttpPost,ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var category = _CategoryRepos.Get(c => c.ID == id);
        if (category == null)
        {
            return NotFound();
        }
        _CategoryRepos.Remove(category);
        _CategoryRepos.Save();
        TempData["Success"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
    }

}