using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Helper;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Session;

namespace App.Web.Controllers
{
    
    public class AutentifikacijaController : Controller
    {
        private  MojContext _context;
        public AutentifikacijaController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new LoginVM {
                ZapamtiPassword = true
            });
            
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _context.KorisnickiNalogs
                .SingleOrDefault(x=>x.KorisnickoIme==input.username && x.Lozinka==input.password);

          
            if (korisnik == null)
            {
                TempData["error_poruka"] = "Pogresan username ili password";
                return View("Index", input);
            }
            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);
            // ovo samo za probu:
            Administrator a = _context.Administrators
                .SingleOrDefault(ad => ad.KorisnickiNalog.KorisnickoIme == input.username);
            Klijent c = _context.Klijents
                .SingleOrDefault(cl => cl.KorisnickiNalog.KorisnickoIme == input.username);
            Radnik r = _context.Radniks
                .SingleOrDefault(ra => ra.KorisnickiNalog.KorisnickoIme == input.username);


            if (a != null)
                return RedirectToAction("HomeAdministrator", "Administrator", new { area = "AdministratorModul" });

            else if (c != null)
                return RedirectToAction("HomeKlijent", "Klijent", new { area = "KlijentModul" });
            else if (r != null)
                return RedirectToAction("HomeRadnik", "Radnik", new { area = "RadnikModul" });
            else

                return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik(null); //ovo sam dodao jer mi nije radio logout kako treba
            return RedirectToAction("Index");
        }
        public IActionResult DodajLogin()
        {
            LoginDodajVM ulazniModel = new LoginDodajVM();

            ulazniModel.gradovi = _context.Grads
                .Select(g => new SelectListItem
                {
                    Value = g.GradId.ToString(),
                    Text=g.NazivGrada
                }).ToList();

            ulazniModel.drzave = _context.Drzavas
                .Select(d => new SelectListItem
                {
                    Value = d.DrzavaId.ToString(),
                    Text=d.NazivDrzave
            }).ToList();


            return View("DodajLogin",ulazniModel);
        }
        public IActionResult SnimiLogin(LoginDodajVM input)
        {
            KorisnickiNalog x = new KorisnickiNalog
            {
                KorisnickoIme = input.korisnickoIme,
                Lozinka = input.lozinka,
                ZapamtiLozinku = input.zapamtiLozinku

            };
            _context.KorisnickiNalogs.Add(x);
            _context.SaveChanges();

            Klijent cl = new Klijent
            {
                KorisnickiNalogId = x.KorisnickiNalogId,
                Ime = input.Ime,
                Prezime = input.Prezime,
                JMBG = input.JMBG,
                Adresa = input.Adresa,
                BrLK = input.BrLK,
                BrojPasosa = input.BrojPasosa,
                DrzavaId=input.drzavaID,
                GradId=input.gradID
                  


            };
            _context.Klijents.Add(cl);
            _context.SaveChanges();
            return RedirectToAction("HomeKlijent", "Klijent", new { area ="KlijentModul"});
        }
    }
}