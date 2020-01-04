using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Areas.RadnikModul.ViewModels;
using App.Web.Helper;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.RadnikModul.Controllers
{
    [Area("RadnikModul")]
    [Autorizacija(administrator: false, radnik: true, klijent: true)]

    public class RezervacijaController : Controller
    {
        private MojContext _context;
        public RezervacijaController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            RezervacijaIndexVM model = new RezervacijaIndexVM
            {
                rowsRzv = _context.Rezervacijas
                .Select(x => new RezervacijaIndexVM.RowRzv
                {
                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaVozacaPoDanu=x.Vozac.CijenaVozacaPoDanu,
                    CijenaVodicaPoDanu =x.TuristickiVodic.CijenaVodicaPoDanu,
                    CijenaTuristRutePoDanu=x.TuristRuta.CijenaTuristRutePoDanu,
                    CijenaVozilaPoDanu =x.Vozilo.CijenaVozilaPoDanu,

                    CijenaUslugePoDanu = x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu + 
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu,
                     
                    UkupnaCijena=(x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu +
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu)
                    *(x.DatumVracanja- x.DatumPreuzimanja).TotalDays * 1.17,
                    TuristRuta=x.TuristRuta.Naziv,
                    TuristickiVodic=x.TuristickiVodic.Naziv,
                    Vozac=x.Vozac.Naziv,
                    Vozilo=x.Vozilo.NazivVozila,
                    
                    Klijent = x.Klijent.Ime,
                    NacinPlacanja = x.NacinPlacanja.Naziv
                    
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiRezervacija(int id)
        {
            Rezervacija x = _context.Rezervacijas.Where(r => r.RezervacijaId == id)
                .Include(q => q.Klijent)
                .Include(s => s.NacinPlacanja)
                .Include(v=>v.Vozac)
                .Include(vzl=>vzl.Vozilo)
                .Include(tr=>tr.TuristRuta)
                .Include(trv=>trv.TuristickiVodic)
                .SingleOrDefault();


            RezervacijaDetaljiVM model = new RezervacijaDetaljiVM
            {

                RezervacijaId = x.RezervacijaId,
                DatumPreuzimanja = x.DatumPreuzimanja,
                DatumVracanja = x.DatumVracanja,
                CijenaVozilaPoDanu=x.Vozilo.CijenaVozilaPoDanu,
                CijenaVozacaPoDanu=x.Vozac.CijenaVozacaPoDanu,
                CijenaVodicaPoDanu=x.TuristickiVodic.CijenaVodicaPoDanu,
                CijenaTuristRutePoDanu=x.TuristRuta.CijenaTuristRutePoDanu,
                CijenaUslugePoDanu = x.Vozilo.CijenaVozilaPoDanu + x.Vozac.CijenaVozacaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu
                + x.TuristickiVodic.CijenaVodicaPoDanu,

                UkupnaCijena =(x.Vozilo.CijenaVozilaPoDanu + x.Vozac.CijenaVozacaPoDanu + 
                x.TuristRuta.CijenaTuristRutePoDanu + x.TuristickiVodic.CijenaVodicaPoDanu)*(x.DatumVracanja - x.DatumPreuzimanja).TotalDays * 1.17,
                

                SelectedKlijentID = x.KlijentId,
                SelectedNacinPlacanjaID = x.NacinPlacanjaId,
                SelectedTuristRutaID=x.TuristRutaId,
                SelectedTuristickiVodicID=x.TuristickiVodicId,
                SelectedVozacID=x.VozacId,
                SelectedVoziloID=x.VoziloId,


                klijent = _context.Klijents
                .Select(c => new SelectListItem
                {
                    Value = c.KlijentId.ToString(),
                    Text = c.Ime+" "+c.Prezime

                }).ToList(),

                nacinPlacanja = _context.NacinPlacanjas
                .Select(c => new SelectListItem
                {
                    Value = c.NacinPlacanjaId.ToString(),
                    Text = c.Naziv

                }).ToList(),


                 turistRuta = _context.TuristRutas
                .Select(c => new SelectListItem
                {
                    Value = c.TuristRutaId.ToString(),
                    Text = c.Naziv + " " + "Cijena po danu je " + c.CijenaTuristRutePoDanu

                }).ToList(),

                turistickiVodic = _context.TuristickiVodics
                .Select(c => new SelectListItem
                {
                    Value = c.TuristickiVodicId.ToString(),
                    Text = c.Naziv + " " + "Cijena po danu je " + c.CijenaVodicaPoDanu

                }).ToList(),

                vozac = _context.Vozacs
                .Select(c => new SelectListItem
                {
                    Value = c.VozacId.ToString(),
                    Text = c.Naziv + " Cijena po danu je "+c.CijenaVozacaPoDanu

                }).ToList(),

                vozilo = _context.Vozilos
                .Select(c => new SelectListItem
                {
                    Value = c.VoziloId.ToString(),
                    Text = c.NazivVozila +" Cijena po danu je "+ c.CijenaVozilaPoDanu

                }).ToList(),
            };
          
            return View("DetaljiRezervacija", model);
        }

        public IActionResult UrediRezervacija(RezervacijaDetaljiVM input)
        {
            Rezervacija x = _context.Rezervacijas.Where(r => r.RezervacijaId == input.RezervacijaId)
                .Include(q => q.Klijent)
                .Include(s => s.NacinPlacanja)
                .Include(v => v.Vozac)
                .Include(vzl => vzl.Vozilo)
                .Include(tr => tr.TuristRuta)
                .Include(trv=>trv.TuristickiVodic)
                .SingleOrDefault();




            x.RezervacijaId = input.RezervacijaId;
            x.DatumPreuzimanja = input.DatumPreuzimanja;
            x.DatumVracanja = input.DatumVracanja;
            //x.Trajanje = input.DatumVracanja - input.DatumPreuzimanja;
            
            x.CijenaUslugePoDanu = input.CijenaUslugePoDanu;
            x.UkupnaCijena = input.CijenaUslugePoDanu * (input.DatumVracanja - input.DatumPreuzimanja).TotalDays * 1.17;

            x.KlijentId = input.SelectedKlijentID;
            x.NacinPlacanjaId = input.SelectedNacinPlacanjaID;
            x.TuristRutaId=input.SelectedTuristRutaID;
            x.TuristickiVodicId = input.SelectedTuristickiVodicID;
            x.VozacId=input.SelectedVozacID;
            x.VoziloId = input.SelectedVoziloID;

            
            _context.Rezervacijas.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rezervacija");
        }

        public IActionResult DodajRezervaciju()
        {
            RezervacijaDodajVM ulazniModel = new RezervacijaDodajVM();

            ulazniModel.vozaci = _context.Vozacs
                .Select(g => new SelectListItem
                {
                    Value = g.VozacId.ToString(),
                    Text = g.Naziv + " Cijena po danu je " + g.CijenaVozacaPoDanu
                }).ToList();

            ulazniModel.vozila = _context.Vozilos
                .Select(vz => new SelectListItem
                {
                    Value = vz.VoziloId.ToString(),
                    Text = vz.NazivVozila + " Cijena po danu je " + vz.CijenaVozilaPoDanu
                }).ToList();

            ulazniModel.turistRute = _context.TuristRutas
                .Select(tr => new SelectListItem
                {
                    Value = tr.TuristRutaId.ToString(),
                    Text = tr.Naziv + " Cijena po danu je " + tr.CijenaTuristRutePoDanu
                }).ToList();

            ulazniModel.turistickiVodici = _context.TuristickiVodics
                .Select(trv => new SelectListItem
                {
                    Value = trv.TuristickiVodicId.ToString(),
                    Text = trv.Naziv + " Cijena po danu je " + trv.CijenaVodicaPoDanu
                }).ToList();

            ulazniModel.klijenti = _context.Klijents
                .Select(k => new SelectListItem
                {
                    Value = k.KlijentId.ToString(),
                    Text = k.Ime+" "+k.Prezime
                }).ToList();

            ulazniModel.naciniPlacanja = _context.NacinPlacanjas
                .Select(np => new SelectListItem
                {
                    Value = np.NacinPlacanjaId.ToString(),
                    Text = np.Naziv
                }).ToList();
            
            // ovo treba prebaciti u SnimiRezervaciju i prvo definisati vrijednosti datuma,
             // pa tek onda dodati Trajanje....
            
            

            return View("DodajRezervaciju", ulazniModel);
        }
        public IActionResult SnimiRezervaciju(RezervacijaDodajVM input)
        {
            //double PDV = 1.17;
           

            Rezervacija rzr = new Rezervacija
            {
                RezervacijaId = input.RezervacijaId,
                DatumPreuzimanja = input.DatumPreuzimanja,
                DatumVracanja = input.DatumVracanja,
                
                //CijenaUslugePoDanu = input.CijenaUslugePoDanu,
                CijenaUslugePoDanu=input.CijenaVozilaPoDanu + input.CijenaVozacaPoDanu
                + input.CijenaVodicaPoDanu + input.CijenaTuristRutePoDanu,
                VozacId = input.vozacID,
                VoziloId = input.voziloID,
                TuristRutaId = input.turistRutaID,
                TuristickiVodicId=input.turistickiVodicID,
                KlijentId = input.klijentID,
                NacinPlacanjaId = input.nacinPlacanjaID,
                

                UkupnaCijena = (input.CijenaVozilaPoDanu + input.CijenaVozacaPoDanu
                + input.CijenaVodicaPoDanu + input.CijenaTuristRutePoDanu) * 
                (input.DatumVracanja-input.DatumPreuzimanja).TotalDays * 1.17

            };

            //ovo ispod provjeravam da li je dostupno vozilo: ....TREBA samo u petlju staviti jedan po jedan dan
            //za pretragu id-a vozila
            int brojac = 0;
            List<Rezervacija> ListaRezervacija = _context.Rezervacijas
                .Include(q => q.Vozilo)
                .Where(c => c.VoziloId == rzr.VoziloId).ToList();



            foreach (Rezervacija x in ListaRezervacija)
            {
                for (DateTime date = rzr.DatumPreuzimanja; date <= rzr.DatumVracanja; date = date.AddDays(1.0))
                {
                    if (x.VoziloId == rzr.VoziloId && date >= x.DatumPreuzimanja && date <= x.DatumVracanja)
                        brojac++;
                }

            }
            if (brojac > 0)
            {
                return RedirectToAction("DodajRezervaciju", "Rezervacija");
                //moracu ponoviti akciju Snimi; ....Morace pisati poruka kao validacija ili slicno...
                //Redirect to Action DodajRezervaciju ili neki return..break ili slicno.
            }

            _context.Rezervacijas.Add(rzr);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rezervacija");
            

        }

        public IActionResult ObrisiRezervaciju(int id)
        {
            Rezervacija x = _context.Rezervacijas.Find(id);
            _context.Rezervacijas.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rezervacija");

        }

    }
}