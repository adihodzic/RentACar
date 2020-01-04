using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Models
{
    public class Vozac
    {
        public int VozacId { get; set; }
        public string Naziv { get; set; }
        public double CijenaVozacaPoDanu { get; set; }
       
        public int RadnikId { get; set; }
        public Radnik Radnik { get; set; }

    }
}
