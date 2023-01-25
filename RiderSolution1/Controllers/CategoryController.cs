using Microsoft.AspNetCore.Mvc;
using RiderSolution1.Data;
using RiderSolution1.Models;

namespace RiderSolution1.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
        
    // GET
    public IActionResult Index()
    {
        IEnumerable<Category> objectCategoryList = _db.Categories.ToList();
        return View(objectCategoryList);
    }
    
    // GET
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category objectCategory)
    {
        if (objectCategory.Name == objectCategory.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "The Display Order name can't be the same as the Category");
        
        if (!ModelState.IsValid) return View();
        
        _db.Categories.Add(objectCategory);
        _db.SaveChanges();
        TempData["Success"] = "Category Created Successfully";
        return RedirectToAction("Index");
    }
    
    // GET
    public IActionResult Edit(int? id)
    {
        if (id is null or <= 0) return NotFound();
        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb is null) return NotFound();
        
        return View();
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category objectCategory)
    {
        if (objectCategory.Name == objectCategory.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "The Display Order name can't be the same as the Category");
        if (!ModelState.IsValid) return View();
        _db.Categories.Update(objectCategory);
        _db.SaveChanges();
        TempData["Success"] = "Category Updated Successfully";
        return RedirectToAction("Index");
    }
}