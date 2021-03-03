using MusicRadioInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRadioInc.ViewModels
{
    public class AlbumPurchaseViewModel
    {
        public Album Album { get; set; }
        public Client Client { get; set; }
        public List<SongSet> Songs { get; set; }
    }
}