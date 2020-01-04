using App.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class VoziloDetaljiVM
    {

        public int VoziloId { get; set; }
        public string NazivVozila { get; set; }
        public DateTime GodinaProizvodnje { get; set; }
        public string BrojMotora { get; set; }
        public double PredjeniKilometri { get; set; }
        public int BrojSjedista { get; set; }
        public string Boja { get; set; }
        public int BrojVrata { get; set; }
        public string RegOznaka { get; set; }
        public double CijenaVozilaPoDanu { get; set; }

        public DateTime DatumRegistracije { get; set; }
        public DateTime DatumIstekaRegistracije { get; set; }

        public string PhotoPath { get; set; }

        public int SelectedRadnikID { get; set; }
        public List<SelectListItem> radnici { get; set; }

        public int SelectedTipVozilaID { get; set; }
        public List<SelectListItem> tipVozila { get; set; }

        public int SelectedMarkaVozilaID { get; set; }
        public List<SelectListItem> markaVozila { get; set; }

        public int SelectedStatusVozilaID { get; set; }
        public List<SelectListItem> statusVozila { get; set; }

        public int SelectedVrstaGorivaID { get; set; }
        public List<SelectListItem> vrstaGoriva { get; set; }

    }
}
