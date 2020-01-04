﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Areas.AdministratorModul.ViewModels
{
    public class TuristickiVodicIndexVM
    {
        public List<RowTV> rowsTV { get; set; }

        public class RowTV
        {
            public int TuristickiVodicId { get; set; }
            public string Naziv { get; set; }
            public string StraniJezik { get; set; }
            public double CijenaVodicaPoDanu { get; set; }
        }
    }
}
