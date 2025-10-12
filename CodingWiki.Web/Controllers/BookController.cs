using CodingWiki.DataAccess.Data;
using CodingWiki.DataAccess.Migrations;
using CodingWiki.Model.Models;
using CodingWiki.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodingWiki.Web.Controllers
{
    public class BookController : Controller
    {
        readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> Books = _db.Books.Include(b => b.Publisher).Include(b => b.AuthorBooks).ThenInclude(ab => ab.Author).ToList();

            //foreach(Book book in Books)
            //{
            //    _db.Entry(book).Reference(b => b.Publisher).Load();
            //    _db.Entry(book).Collection(b => b.AuthorBooks).Load();
            //    foreach(AuthorBookCustomize AuthorBook in book.AuthorBooks)
            //    {
            //        _db.Entry(AuthorBook).Reference(ab => ab.Author).Load();
            //    }
            //}
            return View(Books);
        }

        public IActionResult Upsert(int? Id)
        {
            BookVM bookVM = new()
            {
                PublisherList = _db.Publishers.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Publisher_Id.ToString()
                }).ToList()
            };
            if (Id == 0 || Id == null)
            {
                // create
                return View(bookVM);
            }
            else
            {
                // update
               bookVM.Book = _db.Books.FirstOrDefault(p => p.Id == Id);
                if (bookVM == null)
                    return NotFound();
                return View(bookVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM bookVM)
        {
            if (bookVM == null)
                return BadRequest("BookVM data was not sent");

            if (bookVM.Book.Id == 0)
            {
                // create
                await _db.Books.AddAsync(bookVM.Book);
            }
            else
            {
                // update
                _db.Books.Update(bookVM.Book);
            }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return BadRequest("Id is null or zero");
            Book? book = await _db.Books.FindAsync(Id);
            if (book == null)
                return NotFound($"There is no book with given id {Id}");
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            if (Id == 0 || Id == null)            
                return BadRequest($"BookId {Id} is not valid");

            Book? book = _db.Books.Find(Id);
            BookDetail? bookDetail = _db.BookDetails.FirstOrDefault(bd => bd.Book_Id == Id);
            if (bookDetail == null)
                return View(new BookDetail() { Book = book , Book_Id = book.Id});
            bookDetail.Book_Id = book.Id;
            bookDetail.Book = book;
            return View(bookDetail);
            
        }
        [HttpPost]
        public IActionResult Details(BookDetail bookDetail)
        {
            if(bookDetail == null)
                return BadRequest("BookDetail data was not sent");

            if (bookDetail.BookdDetail_Id == 0)
            {
                // create
                _db.BookDetails.Add(bookDetail);
            }
            else
            {
                // update
                _db.BookDetails.Update(bookDetail);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int Id)
        {
            AuthorBookVM authorBookVM = new()
            {
                AuthorBookList = _db.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book).Where(ab => ab.Book_Id == Id),
                Book = _db.Books.Find(Id),
                AuthorBookCustomize = new AuthorBookCustomize() { Book_Id = Id }
            };
            List<int> ListAssignedAuthors = authorBookVM.AuthorBookList.Where(ab => ab.Book_Id == Id).Select(ab => ab.Author_Id).ToList();
            List<Author> ListNotAssignedAuthors = _db.Authors.Where(ab => !ListAssignedAuthors.Contains(ab.Author_Id)).ToList(); // authors not assigned to this book
            authorBookVM.AuthorList = ListNotAssignedAuthors.Select(a => new SelectListItem()
            {
                Text = a.FullName,
                Value = a.Author_Id.ToString()
            });
            return View(authorBookVM);
        }
        [HttpPost]
        public IActionResult ManageAuthors(AuthorBookVM authorBookVM)
        {
            if(authorBookVM.AuthorBookCustomize.Author_Id == 0 || authorBookVM.AuthorBookCustomize.Book_Id == 0)
                return BadRequest("Author or Book information is missing");
            _db.AuthorBooks.Add(authorBookVM.AuthorBookCustomize);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { Id = authorBookVM.AuthorBookCustomize.Book_Id });
        }

        public IActionResult RemoveAuthors(int authorId, AuthorBookVM authorBookVM)
        {
            if (authorId == 0 || authorBookVM == null)
                return BadRequest("no data for authorId or authorBookVM");

            int BookId = authorBookVM.Book.Id;
            AuthorBookCustomize? authorBook = _db.AuthorBooks.FirstOrDefault(ab => ab.Author_Id == authorId && ab.Book_Id == BookId);
            if (authorBook == null)
                return NotFound($"There is no authBook with given Id {authorId}");

            _db.AuthorBooks.Remove(authorBook);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { Id = BookId });
        }
    }
}
