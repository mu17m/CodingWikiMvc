using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Cosole
{
    internal class Program
    {
        //static ApplicationDbContext _db = new ApplicationDbContext(options =);
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");
            //Console.WriteLine(AddNewBook(new Book() { ISBN = "234456", Title = "New Book", Price = 23.3m, Publisher_Id = 1}));        
            //var book = GetBookById(2);
            //Console.WriteLine(book.Title);
            //GetAllBooks();
        }
        //    static void GetAllBooks()
        //    {
        //        var books = _db.Books.ToList();
        //        bool IsExist = _db.Books.Contains(new Book() { ISBN = "", Title = ""});
        //        foreach (var book in books)
        //        {
        //            Console.WriteLine(book.Title + "-" + book.ISBN);
        //        }
        //    //}
        //    //static int AddNewBook(Book book)
        //    //{
        //    //    if(book == null)
        //    //        return -1;
        //    //    _db.Books.Add(book);
        //    //    return _db.SaveChanges();
        //    //}
        //    //static Book GetBookById(int Id)
        //    //{
        //    //    Book? bookFromDb = _db.Books.FirstOrDefault(b => b.Id == Id);
        //    //    if(bookFromDb == null)
        //    //        return new Book() { ISBN = "", Title = ""};
        //    //    return bookFromDb;
        //    //}
    }
}
