using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Models
{
    public class Vozilo
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

        public bool Ispravnost { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public DateTime DatumIstekaRegistracije { get; set; }

        public string PhotoPath { get; set; }


        public int TipVozilaId { get; set; }
        public TipVozila TipVozila { get; set; }

        public int MarkaVozilaId { get; set; }
        public MarkaVozila MarkaVozila { get; set; }

        public int VrstaGorivaId { get; set; }
        public VrstaGoriva VrstaGoriva { get; set; }

        //public int AdministratorId { get; set; }
        //public Administrator Administrator { get; set; }

        public int RadnikId { get; set; }
        public Radnik Radnik { get; set; }

    }
}
