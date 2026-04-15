using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBooksPublishing.Models
{
    public class Author
    {
        public required string Id { get; set; }
        public required string LName { get; set; }
        public required string FName { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public bool Contract { get; set; }

    }
}
