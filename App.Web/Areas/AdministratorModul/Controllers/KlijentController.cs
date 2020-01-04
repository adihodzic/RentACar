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

    public class KlijentController : Controller
    {
        private MojContext _context;
        public KlijentController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            KlijentIndexVM model = new KlijentIndexVM
            {
                rowsK = _context.Klijents
                .Select(x => new KlijentIndexVM.RowK
                {
                    KlijentId=x.KlijentId,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    KorisnickoIme=x.KorisnickiNalog.KorisnickoIme,
                    Lozinka=x.KorisnickiNalog.Lozinka,
                    JMBG = x.JMBG,
                    Adresa = x.Adresa,
                    Telefon = x.Telefon,
                    Email = x.Email,
                    BrojLK = x.BrLK,
                    BrojPasosa = x.BrojPasosa,
                    Grad = x.Grad.NazivGrada,
                    Drzava = x.Drzava.NazivDrzave
                    
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiKlijent(int id)
        {
            Klijent x = _context.Klijents.Where(k => k.KlijentId == id)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();

            KlijentDetaljiVM model = new KlijentDetaljiVM
            {
                
                KorisnickoIme=x.KorisnickiNalog.KorisnickoIme,
                Lozinka=x.KorisnickiNalog.Lozinka,
                Ime = x.Ime,
                Prezime = x.Prezime,

                JMBG = x.JMBG,
                Adresa = x.Adresa,
                Telefon = x.Telefon,
                Email = x.Email,
                BrojLK = x.BrLK,
                BrojPasosa = x.BrojPasosa,
                SelectedGradID = x.GradId,
                SelectedDrzavaID = x.DrzavaId,

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

            return View("DetaljiKlijent", model);
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
            x.GradId = input.SelectedGradID;
            x.DrzavaId = input.SelectedDrzavaID;


            _context.Klijents.Update(x);
            _context.SaveChanges();
            return View("Index", "Home");
        }
        public IActionResult DodajKlijenta()
        {
            KlijentDodajVM ulazniModel = new KlijentDodajVM();

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


            return View("DodajKlijenta", ulazniModel);
        }
        public IActionResult SnimiKlijenta(KlijentDodajVM input)
        {
            KorisnickiNalog x = new KorisnickiNalog
            {
                KorisnickoIme = input.korisnickoIme,
                Lozinka = input.lozinka,
                ZapamtiLozinku = input.zapamtiLozinku

            };
            _context.KorisnickiNalogs.Add(x);
            _context.SaveChanges();

            Klijent kli = new Klijent
            {
                KorisnickiNalogId = x.KorisnickiNalogId,
                Ime = input.Ime,
                Prezime = input.Prezime,
                JMBG = input.JMBG,
                Adresa = input.Adresa,
                Telefon = input.Telefon,
                Email = input.Email,
                BrLK = input.BrojLK,
                BrojPasosa = input.BrojPasosa,
                GradId=input.gradID,
                DrzavaId=input.drzavaID
                

            };
            _context.Klijents.Add(kli);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ObrisiKlijenta(int id)
        {
            Klijent x = _context.Klijents.Find(id);
            _context.Klijents.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        
    }
}