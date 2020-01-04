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

    public class RadnikController : Controller
    {
        private MojContext _context;
        public RadnikController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            RadnikIndexVM model = new RadnikIndexVM
            {
                rowsR = _context.Radniks
                .Select(x => new RadnikIndexVM.RowR
                {
                    RadnikId = x.RadnikId,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    JMBG = x.JMBG,
                    Adresa = x.Adresa,
                    Telefon = x.Telefon,
                    Email = x.Email,
                    GodineStaza=x.GodineStaza,
                    KorisnickoIme=x.KorisnickiNalog.KorisnickoIme,
                    Pozicija=x.Pozicija,
                    Grad = x.Grad.NazivGrada,
                    Drzava = x.Drzava.NazivDrzave
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiRadnik(int id)
        {
            Radnik x = _context.Radniks.Where(r => r.RadnikId == id)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();

            RadnikDetaljiVM model = new RadnikDetaljiVM
            {

                Ime = x.Ime,
                Prezime = x.Prezime,
                JMBG = x.JMBG,
                Adresa = x.Adresa,
                Telefon = x.Telefon,
                Email = x.Email,
                GodineStaza = x.GodineStaza,
                KorisnickoIme = x.KorisnickiNalog.KorisnickoIme,
                Pozicija = x.Pozicija,
                SelectedGradID = x.GradId,
                SelectedDrzavaID = x.DrzavaId
            };

            return View("DetaljiRadnik", model);
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
            return View("Index", "Home");
        }
        public IActionResult DodajRadnika()
        {
            RadnikDodajVM ulazniModel = new RadnikDodajVM();

            ulazniModel.gradovi = _context.Grads
                .Select(g => new SelectListItem
                {
                    Value = g.GradId.ToString(),
                    Text = g.NazivGrada
                }).ToList();

            ulazniModel.drzave = _context.Drzavas
                .Select(d => new SelectListItem
                {
                    Value = d.DrzavaId.ToString(),
                    Text = d.NazivDrzave
                }).ToList();


            return View("DodajRadnika", ulazniModel);
        }
        public IActionResult SnimiRadnika(RadnikDodajVM input)
        {
            KorisnickiNalog x = new KorisnickiNalog
            {
                KorisnickoIme = input.korisnickoIme,
                Lozinka = input.lozinka,
                ZapamtiLozinku = input.zapamtiLozinku

            };
            _context.KorisnickiNalogs.Add(x);
            _context.SaveChanges();

            Radnik rad = new Radnik
            {
                KorisnickiNalogId = x.KorisnickiNalogId,
                Ime = input.Ime,
                Prezime = input.Prezime,
                JMBG = input.JMBG,
                Adresa = input.Adresa,
                Telefon = input.Telefon,
                Email = input.Email,
                GradId = input.gradID,
                DrzavaId = input.drzavaID,
                Pozicija =input.Pozicija,
                GodineStaza=input.GodineStaza
               
            };
            _context.Radniks.Add(rad);
            _context.SaveChanges();
            return RedirectToAction("Index","Radnik");
        }

        public IActionResult ObrisiRadnika(int id)
        {
            Radnik x = _context.Radniks.Find(id);
            _context.Radniks.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
      
    }
}