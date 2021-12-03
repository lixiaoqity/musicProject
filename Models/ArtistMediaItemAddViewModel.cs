using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistMediaItemAddViewModel
    {
        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Range(1, Int32.MaxValue)]
        public int? ArtistId { get; set; }

        public string ArtistName { get; set; }

        [Required]
        public HttpPostedFileBase MediaUpload { get; set; }
    }
}