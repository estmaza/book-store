using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entity
{
    public class Book : EntityBase
    {
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int Pages { get; set; }

        [StringLength(512)]
        public string Annotation { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
