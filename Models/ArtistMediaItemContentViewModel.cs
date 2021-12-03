using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6.Models
{
    public class ArtistMediaItemContentViewModel
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}