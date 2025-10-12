using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.ViewModels
{
    public class AuthorBookVM
    {
        public AuthorBookCustomize? AuthorBookCustomize { get; set; }
        public Book? Book { get; set; }
        public IEnumerable<AuthorBookCustomize>? AuthorBookList { get; set; } // for multiple authors
        public IEnumerable<SelectListItem>? AuthorList { get; set; } // for dropdown
    }
}
