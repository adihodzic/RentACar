using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.RadnikModul.ViewModels
{
    public class TuristRutaDetaljiVM

    {
        public int TuristRutaId { get; set; }
        public string Opis { get; set; }
        public string Naziv { get; set; }
        public double CijenaTuristRutePoDanu { get; set; }
        
    }
}
