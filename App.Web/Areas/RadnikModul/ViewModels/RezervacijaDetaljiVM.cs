using App.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
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

        public int SelectedVozacID { get; set; }
        public List<SelectListItem> vozac { get; set; }

        public int SelectedVoziloID { get; set; }
        public List<SelectListItem> vozilo { get; set; }

        public int SelectedTuristRutaID { get; set; }
        public List<SelectListItem> turistRuta { get; set; }

        public int SelectedTuristickiVodicID { get; set; }
        public List<SelectListItem> turistickiVodic { get; set; }

        public int SelectedKlijentID { get; set; }
        public List<SelectListItem> klijent { get; set; }

        public int SelectedNacinPlacanjaID { get; set; }
        public List<SelectListItem> nacinPlacanja { get; set; }

        public double UkupnaCijena { get; set; }

    }
}
