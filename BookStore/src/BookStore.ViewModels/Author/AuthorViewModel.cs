using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Books = new List<int>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(512)]
        public string Biography { get; set; }

        [Display(Name = "Number of books")]
        public List<int> Books { get; set; }
    }
}
