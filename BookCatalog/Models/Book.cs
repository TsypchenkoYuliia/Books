using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required]
        [StringLength(150), MinLength(2)]
        public string Title { get; set; }
        [Required]
        [StringLength(150), MinLength(2)]
        public string PublishingHouse { get; set; }
        [Required]
        [StringLength(150), MinLength(5)]
        public string Author { get; set; }
        [Required]
        [StringLength(4), MinLength(4)]
        public string Year { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
