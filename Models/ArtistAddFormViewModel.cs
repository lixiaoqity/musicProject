using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment6.Models
{
    public class ArtistAddFormViewModel : ArtistAddViewModel
    {
        [Required]
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }
    }
}