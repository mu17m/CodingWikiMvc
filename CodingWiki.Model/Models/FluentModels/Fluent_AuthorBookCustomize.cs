using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class Fluent_AuthorBookCustomize
    {
        public int Author_Id { get; set; }
        public int Book_Id { get; set; }
        public Fluent_Author? Author { get; set; }
        public Fluent_Book? Book { get; set; }
        public string? CustomNote { get; set; }
    }
}
