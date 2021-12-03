using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class GenreBaseViewModel
    {
        [Display(Name = "Genre Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
    }
}