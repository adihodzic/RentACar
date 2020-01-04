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
    [Autorizacija(administrator:true, radnik:false, klijent:false)]
    public class AdministratorController : Controller
    {
        private MojContext _context;
        public AdministratorController(MojContext context)
        {
            _context = context;
        }
        public IActionResult HomeAdministrator()
        {
            return View("HomeAdministrator");
        }
        public IActionResult ProfilAdministrator()
        {
            AdministratorDetaljiVM model = null;
            KorisnickiNalog korisnik =HttpContext.GetLogiraniKorisnik();
            if (korisnik != null)
            {
                Administrator x = _context.Administrators.Where(ad => ad.KorisnickiNalogId == korisnik.KorisnickiNalogId)
                    .Include(q => q.KorisnickiNalog)
                    .SingleOrDefault();

                model = new AdministratorDetaljiVM
                {
                    AdministratorId = x.AdministratorId,
                    Ime = x.Ime,
                    Adresa = x.Adresa,
                    SelectedDrzavaID = x.DrzavaId,
                    SelectedGradID=x.GradId,
                    Prezime = x.Prezime,
                    KorisnickoIme = x.KorisnickiNalog.KorisnickoIme,
                    Lozinka = x.KorisnickiNalog.Lozinka,
                    Email = x.Email,
                    JMBG = x.JMBG,
                    ItCertifikat = x.ITCertifikat,
                    IzjavaZastitaPodataka = x.IzjavaZastitaPodataka,
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
            return View("ProfilAdministrator", model);
        }
        public IActionResult Index()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik == null)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area=""});
            }
            AdministratorIndexVM model = new AdministratorIndexVM
            {
                rowsA = _context.Administrators
                .Select(x => new AdministratorIndexVM.RowA
                {
                    AdministratorId=x.AdministratorId,
                    KorisnickoIme=x.KorisnickiNalog.KorisnickoIme,
                    Lozinka=x.KorisnickiNalog.Lozinka,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    JMBG = x.JMBG,
                    Adresa = x.Adresa,

                    Telefon = x.Telefon,
                    Email = x.Email,
                    ItCertifikat = x.ITCertifikat,
                    IzjavaZastitaPodataka = x.IzjavaZastitaPodataka,
                    Grad = x.Grad.NazivGrada,
                    Drzava = x.Drzava.NazivDrzave
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiAdministrator(int id)
        {
            Administrator x = _context.Administrators.Where(a => a.AdministratorId == id)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();


            AdministratorDetaljiVM model = new AdministratorDetaljiVM

            {
                AdministratorId = x.AdministratorId,
                KorisnickoIme = x.KorisnickiNalog.KorisnickoIme,
                Lozinka = x.KorisnickiNalog.Lozinka,
                Ime = x.Ime,
                Prezime = x.Prezime,
                JMBG = x.JMBG,
                Adresa = x.Adresa,

                Telefon = x.Telefon,
                Email = x.Email,
                ItCertifikat = x.ITCertifikat,
                IzjavaZastitaPodataka = x.IzjavaZastitaPodataka,
                SelectedGradID=x.GradId,
                SelectedDrzavaID=x.DrzavaId,

                grad = _context.Grads
                .Select(c => new SelectListItem {
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
            
            
            return View("DetaljiAdministrator", model);
        }
        public IActionResult UrediAdministrator(AdministratorDetaljiVM input)
        {
            Administrator x = _context.Administrators.Where(a => a.AdministratorId == input.AdministratorId)
                .Include(q => q.KorisnickiNalog)
                .SingleOrDefault();

            x.KorisnickiNalog.KorisnickoIme = input.KorisnickoIme;
            x.KorisnickiNalog.Lozinka = input.Lozinka;
            x.Ime = input.Ime;
            x.Prezime = input.Prezime;
            x.JMBG = input.JMBG;
            x.Adresa = input.Adresa;

            x.Telefon = input.Telefon;
            x.Email = input.Email;
            x.ITCertifikat = input.ItCertifikat;
            x.IzjavaZastitaPodataka = input.IzjavaZastitaPodataka;
            x.GradId = input.SelectedGradID;
            x.DrzavaId = input.SelectedDrzavaID;

        

            _context.Administrators.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Administrator");
        }
        public IActionResult DodajAdministratora()
        {
            AdministratorDodajVM ulazniModel = new AdministratorDodajVM();

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


            return View("DodajAdministratora", ulazniModel);
        }
        public IActionResult SnimiAdministratora(AdministratorDodajVM input)
        {
            KorisnickiNalog x = new KorisnickiNalog
            {
                KorisnickoIme = input.korisnickoIme,
                Lozinka = input.lozinka,
                ZapamtiLozinku = input.zapamtiLozinku

            };
            _context.KorisnickiNalogs.Add(x);
            _context.SaveChanges();

            Administrator ad = new Administrator
            {
                KorisnickiNalogId = x.KorisnickiNalogId,
                Ime = input.Ime,
                Prezime = input.Prezime,
                JMBG = input.JMBG,
                Adresa = input.Adresa,
                Telefon=input.Telefon,
                Email=input.Email,
                GradId=input.gradID,
                 DrzavaId=input.drzavaID,
                ITCertifikat=input.ItCertifikat,
                IzjavaZastitaPodataka = input.IzjavaZastitaPodataka
            };
            _context.Administrators.Add(ad);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ObrisiAdministratora(int id)
        {
            Administrator x = _context.Administrators.Find(id);
            _context.Administrators.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

       
    }
}