using App.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class VoziloIndexVM
    {
        public List<RowVzl> rowsVzl { get; set; }

        public class RowVzl
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

            public string TipVozila { get; set; }

            public string MarkaVozila { get; set; }

            public string VrstaGoriva { get; set; }

            public string Radnik { get; set; }

        }
    }
}
