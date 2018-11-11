using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Authors = new List<int>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number between 1 and 10")]
        public int Rating { get; set; }

        [Required]
        public int Pages { get; set; }

        [StringLength(512)]
        public string Annotation { get; set; }

        public List<int> Authors { get; set; }
    }
}
