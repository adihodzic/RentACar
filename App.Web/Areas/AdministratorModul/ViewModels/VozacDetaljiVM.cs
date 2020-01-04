using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.AdministratorModul.ViewModels
{
    public class VozacDetaljiVM
    {
        public int VozacId { get; set; }
        public string Naziv { get; set; }
        public double CijenaVozacaPoDanu { get; set; }
        //pogledati StatusVozacaId

    }
}
