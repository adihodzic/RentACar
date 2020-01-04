using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.AdministratorModul.ViewModels
{
    public class AdministratorDetaljiVM
    {

        public int AdministratorId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }


        public string JMBG { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


        public string ItCertifikat { get; set; }
        public string IzjavaZastitaPodataka { get; set; }

        public int SelectedGradID { get; set; }
        public List<SelectListItem>grad { get; set; }

        public int SelectedDrzavaID { get; set; }
        public List<SelectListItem> drzava { get; set; }

    }
}
