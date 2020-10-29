using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(150), MinLength(2)]
        public string Title { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
