using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Areas.KlijentModul.ViewModels;
using App.Web.Helper;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.KlijentModul.Controllers
{
    [Area("KlijentModul")]
    [Autorizacija(administrator: false, radnik: false, klijent: true)]

    public class KlijentController : Controller
    {
        private MojContext _context;
        public KlijentController(MojContext context)
        {
            _context = context;
        }



        public IActionResult HomeKlijent()
        {
            return View("HomeKlijent");
        }
        public IActionResult UrediKlijent(KlijentDetaljiVM input)
        {
            Klijent x = _context.Klijents.Where(a => a.KlijentId == input.KlijentId)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();


            x.KlijentId = input.KlijentId;
            x.KorisnickiNalog.KorisnickoIme = input.KorisnickoIme;
            x.KorisnickiNalog.Lozinka = input.Lozinka;
            x.Ime = input.Ime;
            x.Prezime = input.Prezime;
            x.JMBG = input.JMBG;
            x.Adresa = input.Adresa;

            x.Telefon = input.Telefon;
            x.Email = input.Email;
            x.BrLK = input.BrojLK;
            x.BrojPasosa = input.BrojPasosa;
            x.GradId = input.SelectedGradID;
            x.DrzavaId = input.SelectedDrzavaID;


            _context.Klijents.Update(x);
            _context.SaveChanges();
            return RedirectToAction("ProfilKlijent", "Klijent");
        }
        public IActionResult ProfilKlijent()
        {
            KlijentDetaljiVM model = null;
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik != null)
            {
                Klijent x = _context.Klijents.Where(kli => kli.KorisnickiNalogId == korisnik.KorisnickiNalogId)
                    .Include(q => q.KorisnickiNalog)
                    .SingleOrDefault();

                model = new KlijentDetaljiVM
                {
                    KlijentId = x.KlijentId,
                    Ime = x.Ime,
                    Adresa = x.Adresa,
                    SelectedDrzavaID = x.DrzavaId,
                    SelectedGradID = x.GradId,
                    Prezime = x.Prezime,
                    KorisnickoIme = x.KorisnickiNalog.KorisnickoIme,
                    Lozinka = x.KorisnickiNalog.Lozinka,
                    Email = x.Email,
                    JMBG = x.JMBG,
                    BrojLK=x.BrLK,
                    BrojPasosa=x.BrojPasosa,
                    Telefon = x.Telefon,
                    

                    grad = _context.Grads
                    .Select(c => new SelectListItem
                    {
                        Value = c.GradId.ToString(),
                        Text = c.NazivGrada

                    }).ToList(),

                    drzava = _context.Drzavas
                    .Select(c => new SelectListItem
                    {
                        Value = c.DrzavaId.ToString(),
                        Text = c.NazivDrzave

                    }).ToList()
                };


            }
            else
            {
                RedirectToAction("Home", "Index");
            }
            return View("ProfilKlijent", model);
        }
    }
}