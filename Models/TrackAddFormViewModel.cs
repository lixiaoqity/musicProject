using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment6.Models
{
    public class TrackAddFormViewModel
    {

        [Display(Name = "Clerk who helps with album tasks")]
        [StringLength(220)]
        public string Clerk { get; set; }

        [StringLength(220)]
        [Display(Name = "Composer names (comma-separated)")]
        public string Composers { get; set; }

        [StringLength(120)]
        [Display(Name = "Track genre")]
        public SelectList Genre { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [Range(1, Int32.MaxValue)]
        [Display(Name = "Album Id")]
        public int? AlbumId { get; set; }

        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Sample clip"), DataType(DataType.Upload)]
        public String AudioUpload { get; set; }

    }
}