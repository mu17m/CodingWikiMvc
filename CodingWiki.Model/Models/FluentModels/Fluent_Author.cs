using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.Model.Models
{
    public class Fluent_Author
    {
        public int Author_Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Location { get; set; }
        public List<Fluent_AuthorBookCustomize>? AuthorBooks { get; set; }

        public string FullName 
        { 
            get { return $"{FirstName} {LastName}"; } 
        } 
    }
}
