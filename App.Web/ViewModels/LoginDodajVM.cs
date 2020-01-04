using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ViewModels
{
    public class LoginDodajVM
    {
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public bool zapamtiLozinku { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string JMBG { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public string BrojPasosa { get; set; }
        public string BrLK { get; set; }

        public int gradID { get; set; }
        public List<SelectListItem> gradovi { get; set; }

        public int drzavaID { get; set; }
        public List<SelectListItem> drzave { get; set; }
    }
}
