using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KatarinaZvkovic.Net13.Models
{
    public class Autobus
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string OznakaLinije { get; set; }
        [Range(2000,2021)]
        public int GodinaProizvodnje { get; set; }
    }
}