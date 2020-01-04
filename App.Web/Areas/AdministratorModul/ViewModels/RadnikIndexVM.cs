using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.AdministratorModul.ViewModels
{
    public class RadnikIndexVM
    {
        public List<RowR> rowsR { get; set; }

        public class RowR
        {
            public int RadnikId { get; set; }
            public string KorisnickoIme { get; set; }
            public string Lozinka { get; set; }

            public string Ime { get; set; }
            public string Prezime { get; set; }
          

            public string JMBG { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }

            public string Pozicija { get; set; }
            public int GodineStaza { get; set; }

            
            public string Grad { get; set; }
            public string Drzava { get; set; }
            
        }
    }
}
