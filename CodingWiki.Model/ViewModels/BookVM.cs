using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public List<SelectListItem> PublisherList { get; set; }
    }
}
