using MusicRadioInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRadioInc.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public List<SongSet> SongList { get; set; }
    }
}