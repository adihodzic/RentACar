using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Models;
using App.Web.Areas.RadnikModul.ViewModels;
using App.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.RadnikModul.Controllers
{
    [Area("RadnikModul")]
    [Autorizacija(administrator: false, radnik: true, klijent: false)]

    public class TuristRutaController : Controller
    {
        private MojContext _context;
        public TuristRutaController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TuristRutaIndexVM model = new TuristRutaIndexVM
            {
                rowsTR = _context.TuristRutas
                .Select(x => new TuristRutaIndexVM.RowTR
                {
                    TuristRutaId=x.TuristRutaId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    CijenaTuristRutePoDanu=x.CijenaTuristRutePoDanu,

                }).ToList()
            };
            return View("Index", model);
        }

        public IActionResult DetaljiTuristRuta(int id)
        {
            TuristRuta x = _context.TuristRutas.Where(t => t.TuristRutaId == id)
                
                .SingleOrDefault();
            TuristRutaDetaljiVM model = new TuristRutaDetaljiVM
            {
                TuristRutaId = x.TuristRutaId,
                Naziv = x.Naziv,
                Opis = x.Opis,
                CijenaTuristRutePoDanu = x.CijenaTuristRutePoDanu,

            };

            return View("DetaljiTuristRuta", model);
        }

        public IActionResult UrediTuristRuta(TuristRutaDetaljiVM input)
        {
            TuristRuta x = _context.TuristRutas.Where(t => t.TuristRutaId == input.TuristRutaId)
                .SingleOrDefault();

            x.TuristRutaId = input.TuristRutaId;
            x.Naziv = input.Naziv;
            x.Opis = input.Opis;
            x.CijenaTuristRutePoDanu = input.CijenaTuristRutePoDanu;


            _context.TuristRutas.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DodajTuristRutu()
        {
            TuristRutaDodajVM ulazniModel = new TuristRutaDodajVM();


            return View("DodajTuristRutu", ulazniModel);
        }
        public IActionResult SnimiTuristRutu(TuristRutaDodajVM input)
        {
            TuristRuta tr = new TuristRuta
            {
                Naziv = input.Naziv,
                Opis = input.Opis,
                CijenaTuristRutePoDanu=input.CijenaTuristRutePoDanu,
                TuristRutaId = input.TuristRutaId,
                


            };
            _context.TuristRutas.Add(tr);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ObrisiTuristRutu(int id)
        {
            TuristRuta x = _context.TuristRutas.Find(id);
            _context.TuristRutas.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}