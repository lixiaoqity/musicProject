using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment6.Models
{
    public class AlbumAddFormViewModel : AlbumAddViewModel
    {
        [Display(Name = "Genre Name")]
        public SelectList GenreList { get; set; }

        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

    }
}