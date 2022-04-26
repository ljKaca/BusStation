using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KatarinaZvkovic.Net13.Models
{
    public class Putnik
    {
        public int Id { get; set; }
        [Required]
        [StringLength(140)]
        public string ImePrezime { get; set; }
        [Required]
        [Range(1900,2021)]
        public int GodinaRodjenja { get; set; }
        [Required]
        [StringLength(200)]
        public string AdresaStanovanja { get; set; }
        [Required]
        [StringLength(20)]
        public string TipKarte { get; set; }
        public int AutobusId { get; set; }
        public Autobus Autobus { get; set; }
    }
}