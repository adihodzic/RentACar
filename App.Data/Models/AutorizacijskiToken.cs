using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Data.Models
{
    public class AutorizacijskiToken
    {
        public int AutorizacijskiTokenId { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
    }
}
