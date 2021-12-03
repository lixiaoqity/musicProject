using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistBaseViewModel : ArtistAddViewModel
    {
        [Display(Name = "Artist Id")]
        public int Id { get; set; }
    }
}