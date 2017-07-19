using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entity
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
