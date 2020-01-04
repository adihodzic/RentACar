using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Models
{
    public class TuristickiVodic
    {
        public int TuristickiVodicId { get; set; }
        public string Naziv { get; set; }
        public string StraniJezik { get; set; }
        public double CijenaVodicaPoDanu { get; set; }

    }
}
