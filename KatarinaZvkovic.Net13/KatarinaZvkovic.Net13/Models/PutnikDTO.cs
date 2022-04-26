using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatarinaZvkovic.Net13.Models
{
    public class PutnikDTO
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string AdresaStanovanja { get; set; }
        public int GodinaRodjenja { get; set; }
        public string AutobusOznakaLinije { get; set; }
        public string TipKarte { get; set; }

    }
}