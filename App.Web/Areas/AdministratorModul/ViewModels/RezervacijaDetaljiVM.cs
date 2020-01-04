using App.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.AdministratorModul.ViewModels
{
    public class RezervacijaDetaljiVM
    {
        public int RezervacijaId { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public double CijenaVozacaPoDanu { get; set; }
        public double CijenaVozilaPoDanu { get; set; }
        public double CijenaVodicaPoDanu { get; set; }
        public double CijenaTuristRutePoDanu { get; set; }
        public double CijenaUslugePoDanu { get; set; }




        public TimeSpan Trajanje { get; set; }

        public string Vozac { get; set; }

        public string VoziloIme { get; set; }

        public string TuristRutaIme { get; set; }

        public string TuristickiVodic { get; set; }

        public string KlijentIme { get; set; }

        public string NacinPlacanja { get; set; }

        public double UkupnaCijena { get; set; }

    }
}
