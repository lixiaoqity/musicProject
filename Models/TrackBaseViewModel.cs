using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Assignment6.Models
{
    public class TrackBaseViewModel
    {
        public TrackBaseViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }

        [Display(Name = "Track Id")]
        public int Id { get; set; }

        [Display(Name = "Clerk who helps with album tasks")]
        [StringLength(220)]
        public string Clerk { get; set; }

        [StringLength(220)]
        [Display(Name = "Composer names (comma-separated)")]
        public string Composers { get; set; }

        [StringLength(120)]
        [Display(Name = "Track genre")]
        public string Genre { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }

        [Display(Name = "Album name")]
        public IEnumerable<string> AlbumNames
        {
            get
            {
                var names = new List<string>();
                names = Albums.Select(a => a.Name).ToList();
                return names;
            }
        }
    }
}