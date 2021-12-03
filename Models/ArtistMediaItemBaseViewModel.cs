using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistMediaItemBaseViewModel
    {
        public ArtistMediaItemBaseViewModel()
        {
            Timestamp = DateTime.Now;

            // StringId generator
            // Code is from Mads Kristensen
            // http://madskristensen.net/post/generate-unique-strings-and-numbers-in-c

            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }


        [Required, StringLength(100)]
        [Display(Name = "Unique identifier")]
        public string StringId { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Added on date/time")]
        public DateTime Timestamp { get; set; }

        public string ContentType { get; set; }

    }
}