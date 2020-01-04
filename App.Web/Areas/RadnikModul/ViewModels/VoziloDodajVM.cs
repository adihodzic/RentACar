using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class VoziloDodajVM
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

        public IFormFile Photo { get; set; }

       
        public int tipVozilaID { get; set; }
        public List<SelectListItem>tipoviVozila { get; set; }

        public int markaVozilaID { get; set; }
        public List<SelectListItem> markeVozila { get; set; }


        public int vrstaGorivaID { get; set; }
        public List<SelectListItem> vrsteGoriva { get; set; }

        public int radnikID { get; set; }
        public List<SelectListItem> radnici { get; set; }
    }
}
