using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki.Web.Controllers
{
    public class CategoryController : Controller
    {
        readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? Id)
        {
            Category? category = new() { Name = ""};
            if(Id == null || Id == 0)
            {
                // Create 
                return View(category);
            }
            // Update
            category = _db.Categories.FirstOrDefault(c => c.CategoryId == Id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.CategoryId == 0)
                {
                    // Create
                    await _db.Categories.AddAsync(category);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    // Update
                    _db.Categories.Update(category);
                    await _db.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new()
            {
                new Category { Name = Guid.NewGuid().ToString() },
                new Category { Name = Guid.NewGuid().ToString() },
            };
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new()
            {
                new Category { Name = Guid.NewGuid().ToString() },
                new Category { Name = Guid.NewGuid().ToString() },
                new Category { Name = Guid.NewGuid().ToString() },
                new Category { Name = Guid.NewGuid().ToString() },
                new Category { Name = Guid.NewGuid().ToString() }
            };
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryId).Take(2).ToList();
            if(categories.Count < 1)
                return RedirectToAction(nameof(Index));
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryId).Take(5).ToList();
            if (categories.Count < 1)
                return RedirectToAction(nameof(Index));
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            Category? category = _db.Categories.FirstOrDefault(c => c.CategoryId == Id);
            if(category == null)
            {
                return NotFound();                
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
