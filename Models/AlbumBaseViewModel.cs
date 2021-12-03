using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class AlbumBaseViewModel : AlbumAddViewModel
    {
        [Display(Name = "Album Id")]
        public int Id { get; set; }
    }
}