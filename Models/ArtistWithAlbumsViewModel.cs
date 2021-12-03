using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistWithAlbumsViewModel : ArtistBaseViewModel
    {
        public ArtistWithAlbumsViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
            AlbumsCount = Albums.Count();
            Genres = new List<GenreBaseViewModel>();
        }

        [Display(Name = "List of Albums")]
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }

        [Display(Name = "List of Genres")]
        public IEnumerable<GenreBaseViewModel> Genres { get; set; }


        [Display(Name = "Number of albums")]
        public int AlbumsCount { get; set; }
    }
}