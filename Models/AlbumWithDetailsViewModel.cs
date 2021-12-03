using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class AlbumWithDetailsViewModel : AlbumBaseViewModel
    {
        public AlbumWithDetailsViewModel()
        {
            Artists = new List<ArtistBaseViewModel>();
            Tracks = new List<TrackBaseViewModel>();
            TracksCount = Tracks.Count();
            ArtistsCount = Artists.Count();

        }

        [Display(Name = "List of Artists")]
        public IEnumerable<ArtistBaseViewModel> Artists { get; set; }

        [Display(Name = "List of Tracks")]
        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }

        [Display(Name = "Number of tracks on this album")]
        public int TracksCount { get; set; }

        [Display(Name = "Number of artists on this album")]
        public int ArtistsCount { get; set; }
    }
}