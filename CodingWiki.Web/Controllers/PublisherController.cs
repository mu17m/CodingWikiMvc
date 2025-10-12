using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki.Web.Controllers
{
    public class PublisherController : Controller
    {
        readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Publisher> publishers = _db.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Upsert(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                // create
                return View(new Publisher() { Name = ""});
            }
            else
            {
                // update
                Publisher? publisher = _db.Publishers.FirstOrDefault(p => p.Publisher_Id == Id);
                if(publisher == null)
                    return NotFound();
                return View(publisher);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if(publisher == null)
                return BadRequest("publisher data was not sent");

            if(publisher.Publisher_Id == 0)
            {
                // create
                await _db.Publishers.AddAsync(publisher);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // update
                _db.Publishers.Update(publisher);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if(Id == null || Id == 0)
                return BadRequest("Id is null or zero");
            Publisher? publisher = await _db.Publishers.FindAsync(Id);
            if(publisher == null)
                return NotFound($"There is not publisher with given id {Id}");
            _db.Publishers.Remove(publisher);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
