using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRadioInc.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(300)]
        [Display(Name = "Correo Electrónico")]
        public string Mail { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Dirección")]
        public string Direction { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}