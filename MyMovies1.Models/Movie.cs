using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Cast { get; set; }

    }
}
