using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Areas.RadnikModul.ViewModels;
using App.Web.Helper;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.RadnikModul.Controllers
{
    [Area("RadnikModul")]
    [Autorizacija(administrator: false, radnik: true, klijent: false)]

    public class VoziloController : Controller
    {
        private MojContext _context { get; set; }
        private readonly IHostingEnvironment hostingEnvironment;

        public VoziloController(MojContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        
       
        public IActionResult Index()
        {
            VoziloIndexVM model = new VoziloIndexVM
            {
                rowsVzl = _context.Vozilos
                .Select(x => new VoziloIndexVM.RowVzl
                {
                    VoziloId = x.VoziloId,
                    Boja = x.Boja,
                    BrojMotora = x.BrojMotora,
                    BrojSjedista = x.BrojSjedista,
                    BrojVrata = x.BrojVrata,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    NazivVozila = x.NazivVozila,
                    PredjeniKilometri = x.PredjeniKilometri,
                    RegOznaka = x.RegOznaka,
                    MarkaVozila = x.MarkaVozila.NazivMarke,
                    TipVozila = x.TipVozila.NazivTipa,
                    VrstaGoriva = x.VrstaGoriva.NazivGoriva,
                    CijenaVozilaPoDanu=x.CijenaVozilaPoDanu
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiVozilo(int id)
        {
            Vozilo x = _context.Vozilos.Where(v => v.VoziloId == id)
                .Include(q => q.TipVozila)
                .Include(s => s.MarkaVozila)
                .Include(t => t.VrstaGoriva)
                .SingleOrDefault();

            VoziloDetaljiVM model = new VoziloDetaljiVM
            {

                VoziloId = x.VoziloId,
                Boja = x.Boja,
                BrojMotora = x.BrojMotora,
                BrojSjedista = x.BrojSjedista,
                BrojVrata = x.BrojVrata,
                GodinaProizvodnje = x.GodinaProizvodnje,
                NazivVozila = x.NazivVozila,
                PredjeniKilometri = x.PredjeniKilometri,
                RegOznaka = x.RegOznaka,
                DatumRegistracije=x.DatumRegistracije,
                DatumIstekaRegistracije = x.DatumIstekaRegistracije,
               
                PhotoPath=x.PhotoPath,
                CijenaVozilaPoDanu=x.CijenaVozilaPoDanu,
                

                SelectedRadnikID = x.RadnikId,
                SelectedMarkaVozilaID = x.MarkaVozilaId,
                SelectedTipVozilaID = x.TipVozilaId,
                SelectedVrstaGorivaID = x.VrstaGorivaId,

                radnici = _context.Radniks
                .Select(rd => new SelectListItem
                {
                    Value = rd.RadnikId.ToString(),
                    Text=rd.KorisnickiNalog.KorisnickoIme
                }).ToList(),
                markaVozila = _context.MarkaVozilas
                    .Select(c => new SelectListItem
                    {
                        Value = c.MarkaVozilaId.ToString(),
                        Text = c.NazivMarke
                    }).ToList(),
                tipVozila = _context.TipVozilas
                    .Select(c => new SelectListItem
                    {
                        Value = c.TipVozilaId.ToString(),
                        Text = c.NazivTipa
                    }).ToList(),

                vrstaGoriva = _context.VrstaGorivas
                    .Select(c => new SelectListItem
                    {
                        Value = c.VrstaGorivaId.ToString(),
                        Text = c.NazivGoriva
                    }).ToList(),

            };

            return View("DetaljiVozilo", model);
        }
        public IActionResult UrediVozilo(VoziloDetaljiVM input)
        {
            Vozilo x = _context.Vozilos.Where(v => v.VoziloId == input.VoziloId)
                .Include(q => q.TipVozila)
                .Include(s => s.MarkaVozila)
                .Include(t => t.VrstaGoriva)
                .SingleOrDefault();



            x.VoziloId = input.VoziloId;
            x.Boja = input.Boja;
            x.BrojMotora = input.BrojMotora;
            x.BrojSjedista = input.BrojSjedista;
            x.BrojVrata = input.BrojVrata;
            x.GodinaProizvodnje = input.GodinaProizvodnje;
            x.NazivVozila = input.NazivVozila;
            x.PredjeniKilometri = input.PredjeniKilometri;
            x.RegOznaka = input.RegOznaka;
            x.DatumRegistracije = input.DatumRegistracije;
            x.DatumIstekaRegistracije = input.DatumIstekaRegistracije;
            

            x.PhotoPath = input.PhotoPath; // provjeriti da li je potrebno
            x.CijenaVozilaPoDanu = input.CijenaVozilaPoDanu;

            x.RadnikId = input.SelectedRadnikID;
            x.MarkaVozilaId = input.SelectedMarkaVozilaID;
            x.TipVozilaId = input.SelectedTipVozilaID;
            x.VrstaGorivaId = input.SelectedVrstaGorivaID;


            _context.Vozilos.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Vozilo");
        }

        public IActionResult DodajVozilo()
        {
            VoziloDodajVM ulazniModel = new VoziloDodajVM();

            ulazniModel.radnici = _context.Radniks
                .Select(rd => new SelectListItem
                {
                    Value = rd.RadnikId.ToString(),
                    Text = rd.KorisnickiNalog.KorisnickoIme
                }).ToList();
            ulazniModel.tipoviVozila = _context.TipVozilas
                .Select(tv => new SelectListItem
                {
                    Value = tv.TipVozilaId.ToString(),
                    Text=tv.NazivTipa
                }).ToList();
            ulazniModel.markeVozila = _context.MarkaVozilas
                .Select(mv => new SelectListItem
                {
                    Value=mv.MarkaVozilaId.ToString(),
                    Text=mv.NazivMarke
                }).ToList();
            ulazniModel.vrsteGoriva = _context.VrstaGorivas
                .Select(vg => new SelectListItem
                {
                    Value = vg.VrstaGorivaId.ToString(),
                    Text = vg.NazivGoriva
                }).ToList();
            

            return View("DodajVozilo", ulazniModel);
        }
        public IActionResult SnimiVozilo(VoziloDodajVM input)
        {

            string imeFajla = null;
            if (input.Photo != null)
            {
                //hostingEnvironment.WebRootPath;
                //v.PhotoPath = input.PhotoPath;

                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");   //folder images u wwwroot folderu
                imeFajla = Path.GetFileName(input.Photo.FileName);    //ime Fajla isto je property FileName  u IFormFile interface-u
                var contentType = input.Photo.ContentType; // daje contentType definisan u IFormFile interface-u
                var pathFajla = Path.Combine(uploads, imeFajla); //spaja path i ime
                input.Photo.CopyTo(new FileStream(pathFajla, FileMode.Create));
            }

            Vozilo v = new Vozilo
            {
                VoziloId = input.VoziloId,
                Boja = input.Boja,
                BrojMotora = input.BrojMotora,
                BrojSjedista = input.BrojSjedista,
                BrojVrata = input.BrojVrata,
                GodinaProizvodnje = input.GodinaProizvodnje,
                NazivVozila = input.NazivVozila,
                PredjeniKilometri = input.PredjeniKilometri,
                RegOznaka = input.RegOznaka,
                RadnikId=input.radnikID,
                MarkaVozilaId = input.markaVozilaID,
                TipVozilaId = input.tipVozilaID,
                VrstaGorivaId = input.vrstaGorivaID,
                PhotoPath = imeFajla,
                CijenaVozilaPoDanu=input.CijenaVozilaPoDanu

                

        };
           
               

            _context.Vozilos.Add(v);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ObrisiVozilo(int id)
        {
            Vozilo x = _context.Vozilos.Find(id);
            _context.Vozilos.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

    }
}