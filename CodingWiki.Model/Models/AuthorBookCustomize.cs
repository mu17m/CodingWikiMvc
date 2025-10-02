using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class AuthorBookCustomize
    {
        [ForeignKey("Author")]
        public int Author_Id { get; set; }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        public Author? Author { get; set; }
        public Book? Book { get; set; }
        public string? CustomNote { get; set; }
    }
}
