using App.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class RezervacijaIndexVM
    {
        public List<RowRzv> rowsRzv { get; set; }

        public class RowRzv
        {

            public int RezervacijaId { get; set; }
            public DateTime DatumPreuzimanja { get; set; }
            public DateTime DatumVracanja { get; set; }
            public double CijenaUslugePoDanu { get; set; }

            public double CijenaVozacaPoDanu { get; set; }
            public double CijenaVozilaPoDanu { get; set; }
            public double CijenaVodicaPoDanu { get; set; }
            public double CijenaTuristRutePoDanu { get; set; }

            public string Vozac { get; set; }

            public string Vozilo { get; set; }
            
            public string TuristRuta { get; set; }

            public string TuristickiVodic { get; set; }

            public string Klijent { get; set; }

            public string NacinPlacanja { get; set; }

            public double UkupnaCijena { get; set; }

        }
    }
}
