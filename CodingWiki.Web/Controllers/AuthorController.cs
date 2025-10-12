using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki.Web.Controllers
{
    public class AuthorController : Controller
    {
        readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> Authors = _db.Authors.ToList();
            return View(Authors);
        }

        public IActionResult Upsert(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                // create
                return View(new Author() { FirstName = "", LastName = ""});
            }
            else
            {
                // update
                Author? author = _db.Authors.FirstOrDefault(p => p.Author_Id == Id);
                if (author == null)
                    return NotFound();
                return View(author);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if (author == null)
                return BadRequest("author data was not sent");

            if (author.Author_Id == 0)
            {
                // create
                await _db.Authors.AddAsync(author);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // update
                _db.Authors.Update(author);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return BadRequest("Id is null or zero");
            Author? author = await _db.Authors.FindAsync(Id);
            if (author == null)
                return NotFound($"There is no author with given id {Id}");
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
