using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRadioInc.Models
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        [Required]
        public int Total { get; set; }
        public Album PurchaseAlbum { get; set; }
        public int PurchaseAlbumId { get; set; }
        public Client PurchaseClient { get; set; }
        public int PurchaseClientId { get; set; }
    }
}