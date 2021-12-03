using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistAddViewModel
    {
        public ArtistAddViewModel()
        {
            BirthOrStartDate = DateTime.Now;
        }

        [Display(Name = "Artist photo")]
        public string UrlArtist { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [StringLength(120)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [DataType(DataType.Date), Required]
        [Display(Name = "Birth date, or start date")]
        public DateTime? BirthOrStartDate { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public String Genre { get; set; }

        [StringLength(220)]
        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }

        [Display(Name = "Artist biography")]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

    }
}