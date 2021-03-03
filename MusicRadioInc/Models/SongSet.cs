using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRadioInc.Models
{
    public class SongSet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        public Album SongSetAlbum { get; set; }
        public int SongSetAlbumId { get; set; }
    }
}