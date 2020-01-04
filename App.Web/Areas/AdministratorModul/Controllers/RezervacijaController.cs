using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Areas.AdministratorModul.ViewModels;
using App.Web.Helper;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.AdministratorModul.Controllers
{
    [Area("AdministratorModul")]
    [Autorizacija(administrator: true, radnik: false, klijent: false)]

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
                 //.Where(t => t.Klijent.Ime.Contains(searchString  && ))
                vozila = _context.Vozilos
                 .Select(v => new SelectListItem
                 {
                     Value = v.VoziloId.ToString(),
                     Text = v.NazivVozila
                 }).ToList(),

                klijenti = _context.Klijents
                 .Select(k => new SelectListItem
                 {
                     Value = k.KlijentId.ToString(),
                     Text = k.Ime
                 }).ToList(),

                turistRute = _context.TuristRutas
                 .Select(tr => new SelectListItem
                 {
                     Value = tr.TuristRutaId.ToString(),
                     Text = tr.Naziv
                 }).ToList(),

                rowsRzv = _context.Rezervacijas
                .Select(x => new RezervacijaIndexVM.RowRzv
                {
                   


                    RezervacijaId = x.RezervacijaId,
                    DatumPreuzimanja = x.DatumPreuzimanja,
                    DatumVracanja = x.DatumVracanja,
                    CijenaVozacaPoDanu = x.Vozac.CijenaVozacaPoDanu,
                    CijenaVodicaPoDanu = x.TuristickiVodic.CijenaVodicaPoDanu,
                    CijenaTuristRutePoDanu = x.TuristRuta.CijenaTuristRutePoDanu,
                    CijenaVozilaPoDanu = x.Vozilo.CijenaVozilaPoDanu,

                    CijenaUslugePoDanu = x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu +
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu,

                    UkupnaCijena = (x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu +
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu)
                    * (x.DatumVracanja - x.DatumPreuzimanja).TotalDays * 1.17,
                    TuristRutaIme = x.TuristRuta.Naziv,
                    TuristickiVodic = x.TuristickiVodic.Naziv,
                    Vozac = x.Vozac.Naziv,
                    VoziloIme = x.Vozilo.NazivVozila,

                    KlijentIme = x.Klijent.Ime,
                    NacinPlacanja = x.NacinPlacanja.Naziv

                }).ToList()
                
                

            };
            return View("Index", model);
            //}
            //return RedirectToAction("HomeAdministrator", "Administrator");
        }
        public IActionResult PrikaziPretragu(RezervacijaIndexVM inputPretraga)
        {
            //List<Rezervacija> rezervacije = _context.Rezervacijas
            //    .Where(v => (v.VoziloId == inputPretraga.voziloID) || (v.KlijentId == inputPretraga.klijentID)
            //    || (v.TuristRutaId == inputPretraga.turistRutaID)).ToList();

            
            RezervacijaIndexVM model = new RezervacijaIndexVM
            {
                //voziloID=inputPretraga.voziloID,
                //klijentID=inputPretraga.klijentID,
                //turistRutaID=inputPretraga.turistRutaID,

                rowsRzv = _context.Rezervacijas
                .Where(v => (v.VoziloId == inputPretraga.voziloID) || (v.KlijentId == inputPretraga.klijentID)
                || (v.TuristRutaId == inputPretraga.turistRutaID))
                    .Select(x => new RezervacijaIndexVM.RowRzv
                    {
                        RezervacijaId = x.RezervacijaId,
                        DatumPreuzimanja = x.DatumPreuzimanja,
                        DatumVracanja = x.DatumVracanja,
                        CijenaVozacaPoDanu = x.Vozac.CijenaVozacaPoDanu,
                        CijenaVodicaPoDanu = x.TuristickiVodic.CijenaVodicaPoDanu,
                        CijenaTuristRutePoDanu = x.TuristRuta.CijenaTuristRutePoDanu,
                        CijenaVozilaPoDanu = x.Vozilo.CijenaVozilaPoDanu,

                        CijenaUslugePoDanu = x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu +
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu,

                        UkupnaCijena = (x.Vozac.CijenaVozacaPoDanu + x.Vozilo.CijenaVozilaPoDanu +
                    x.TuristickiVodic.CijenaVodicaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu)
                    * (x.DatumVracanja - x.DatumPreuzimanja).TotalDays * 1.17,
                        TuristRutaIme = x.TuristRuta.Naziv,
                        TuristickiVodic = x.TuristickiVodic.Naziv,
                        Vozac = x.Vozac.Naziv,
                        VoziloIme = x.Vozilo.NazivVozila,

                        KlijentIme = x.Klijent.Ime,
                        NacinPlacanja = x.NacinPlacanja.Naziv
                    }).ToList()

            };

            return View("Index", model); // ovdje sam morao dodati model da bi radilo ispravno
            //return RedirectToAction("Index", "Rezervacija");
        }

        public IActionResult DetaljiRezervacija(int id)
        {
            Rezervacija x = _context.Rezervacijas.Where(r => r.RezervacijaId == id)
                .Include(q => q.Klijent)
                .Include(s => s.NacinPlacanja)
                .Include(v => v.Vozac)
                .Include(vzl => vzl.Vozilo)
                .Include(tr => tr.TuristRuta)
                .Include(trv => trv.TuristickiVodic)
                .SingleOrDefault();


            RezervacijaDetaljiVM model = new RezervacijaDetaljiVM
            {

                RezervacijaId = x.RezervacijaId,
                DatumPreuzimanja = x.DatumPreuzimanja,
                DatumVracanja = x.DatumVracanja,
                CijenaVozilaPoDanu = x.Vozilo.CijenaVozilaPoDanu,
                CijenaVozacaPoDanu = x.Vozac.CijenaVozacaPoDanu,
                CijenaVodicaPoDanu = x.TuristickiVodic.CijenaVodicaPoDanu,
                CijenaTuristRutePoDanu = x.TuristRuta.CijenaTuristRutePoDanu,
                CijenaUslugePoDanu = x.Vozilo.CijenaVozilaPoDanu + x.Vozac.CijenaVozacaPoDanu + x.TuristRuta.CijenaTuristRutePoDanu
                + x.TuristickiVodic.CijenaVodicaPoDanu,

                UkupnaCijena = (x.Vozilo.CijenaVozilaPoDanu + x.Vozac.CijenaVozacaPoDanu +
                x.TuristRuta.CijenaTuristRutePoDanu + x.TuristickiVodic.CijenaVodicaPoDanu) * (x.DatumVracanja - x.DatumPreuzimanja).TotalDays * 1.17,


                KlijentIme = x.Klijent.Ime,
                NacinPlacanja = x.NacinPlacanja.Naziv,
                TuristRutaIme = x.TuristRuta.Naziv,
                TuristickiVodic = x.TuristickiVodic.Naziv,
                Vozac = x.Vozac.Naziv,
                VoziloIme = x.Vozilo.NazivVozila
                               
                
            };

            return View("DetaljiRezervacija", model);
        }

    }    
}