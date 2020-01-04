using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Models
{
    public class Administrator
    {

        public int AdministratorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string JMBG { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public string ITCertifikat { get; set; }
        public string IzjavaZastitaPodataka { get; set; }

        public int GradId { get; set; }
        public Grad Grad { get; set; }

        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }

        public int? KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }

    }   
}
