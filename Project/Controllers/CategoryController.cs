using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;
    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> CategoryList = _context.Categories;
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
            _context.Categories.Add(category);
            _context.SaveChanges();
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
        var category = _context.Categories.Find(id);
        // var categoryFromDBFirst = _context.Categories.FirstOrDefault(c => c.ID == id);
        // var categoryFromDBSingle = _context.Categories.SingleOrDefault(c => c.ID == id);
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
            _context.Categories.Update(category);
            _context.SaveChanges();
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
        var category = _context.Categories.Find(id);
        // var categoryFromDBFirst = _context.Categories.FirstOrDefault(c => c.ID == id);
        // var categoryFromDBSingle = _context.Categories.SingleOrDefault(c => c.ID == id);
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
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction("Index", "Category");
    }

}