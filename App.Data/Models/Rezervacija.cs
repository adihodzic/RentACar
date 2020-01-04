using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Data.Models
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime DatumPreuzimanja { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime DatumVracanja { get; set; }
        public double CijenaUslugePoDanu { get; set; }
        //public double CijenaVodicaPoDanu { get; set; }
        //public double CijenaVozilaPoDanu { get; set; }
        //public double CijenaVozacaPoDanu { get; set; }
        //public double CijenaRutePoDanu { get; set; }

        //public double Trajanje { get; set; }
        public string BrojRacuna { get; set; }
        public double UkupnaCijena { get; set; }
        //public int TrajanjeRentanjaDani { get; set; }
        public DateTime DatumRacuna { get; set; }

        public int NacinPlacanjaId { get; set; }
        public NacinPlacanja NacinPlacanja { get; set; }


        public int VozacId { get; set; }
        public Vozac Vozac { get; set; }

        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }

        public int TuristickiVodicId { get; set; }
        public TuristickiVodic TuristickiVodic { get; set; }

        public int TuristRutaId { get; set; }
        public TuristRuta TuristRuta { get; set; }

        public int KlijentId { get; set; }
        public Klijent Klijent { get; set; }
    }
}
