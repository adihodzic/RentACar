using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class RezervacijaDodajVM
    {
        public int RezervacijaId { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public double CijenaUslugePoDanu { get; set; }
        public double CijenaVozacaPoDanu { get; set; }
        public double CijenaVozilaPoDanu { get; set; }
        public double CijenaVodicaPoDanu { get; set; }
        public double CijenaTuristRutePoDanu { get; set; }


        public int vozacID { get; set; }
        public List<SelectListItem> vozaci { get; set; }

        public int voziloID { get; set; }
        public List<SelectListItem> vozila { get; set; }

        public int turistRutaID { get; set; }
        public List<SelectListItem> turistRute { get; set; }

        public int turistickiVodicID { get; set; }
        public List<SelectListItem> turistickiVodici { get; set; }

        public int klijentID { get; set; }
        public List<SelectListItem> klijenti { get; set; }

        public int nacinPlacanjaID { get; set; }
        public List<SelectListItem> naciniPlacanja { get; set; }

        public int Trajanje { get; set; }
        public double UkupnaCijena { get; set; }
    }
}
