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
    [Autorizacija(administrator: false, radnik: true, klijent: false)]

    public class RadnikController : Controller
    {
        private MojContext _context;
        public RadnikController(MojContext context)
        {
            _context = context;
        }
        public IActionResult HomeRadnik()
        {
            return View("HomeRadnik");
        }


        public IActionResult ProfilRadnik()
        {
            RadnikDetaljiVM model = null;
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik != null)
            {
                Radnik x = _context.Radniks.Where(rad => rad.KorisnickiNalogId == korisnik.KorisnickiNalogId)
                    .Include(q => q.KorisnickiNalog)
                    .SingleOrDefault();

                model = new RadnikDetaljiVM
                {
                    RadnikId = x.RadnikId,
                    Ime = x.Ime,
                    Adresa = x.Adresa,
                    SelectedDrzavaID = x.DrzavaId,
                    SelectedGradID = x.GradId,
                    Prezime = x.Prezime,
                    KorisnickoIme = x.KorisnickiNalog.KorisnickoIme,
                    Lozinka = x.KorisnickiNalog.Lozinka,
                    Email = x.Email,
                    JMBG = x.JMBG,
                    GodineStaza = x.GodineStaza,
                    Pozicija = x.Pozicija,
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
            return View("ProfilRadnik", model);
        }
        public IActionResult UrediRadnik(RadnikDetaljiVM input)
        {
            Radnik x = _context.Radniks.Where(a => a.RadnikId == input.RadnikId)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();


            x.KorisnickiNalog.KorisnickoIme = input.KorisnickoIme;
            x.KorisnickiNalog.Lozinka = input.Lozinka;
            x.Ime = input.Ime;
            x.Prezime = x.Prezime;
            x.JMBG = input.JMBG;
            x.Adresa = input.Adresa;
            x.GodineStaza = input.GodineStaza;
            x.Pozicija = input.Pozicija;

            x.Telefon = input.Telefon;
            x.Email = input.Email;

            x.GradId = input.SelectedGradID;
            x.DrzavaId = input.SelectedDrzavaID;



            _context.Radniks.Update(x);
            _context.SaveChanges();
            return View("ProfilRadnik", "Radnik");
        }
    }
}