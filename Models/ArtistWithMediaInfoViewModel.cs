using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment6.Models
{
    public class ArtistWithMediaInfoViewModel : ArtistBaseViewModel
    {
        public ArtistWithMediaInfoViewModel()
        {
            ArtistMediaItems = new List<ArtistMediaItemBaseViewModel>();
        }

        public ICollection<ArtistMediaItemBaseViewModel> ArtistMediaItems { get; set; }
    }
}