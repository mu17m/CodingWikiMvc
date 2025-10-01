using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public required string GenreName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
