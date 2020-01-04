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

    public class TuristickiVodicController : Controller
    {
        private MojContext _context;
        public TuristickiVodicController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TuristickiVodicIndexVM model = new TuristickiVodicIndexVM
            {
                rowsTV = _context.TuristickiVodics
                .Select(x => new TuristickiVodicIndexVM.RowTV
                {
                    TuristickiVodicId=x.TuristickiVodicId,   
                    Naziv = x.Naziv,
                    StraniJezik = x.StraniJezik,
                    CijenaVodicaPoDanu=x.CijenaVodicaPoDanu
                }).ToList()


            };
            return View("Index", model);
        }

        public IActionResult DetaljiTuristickiVodic(int id)
        {
            TuristickiVodic x = _context.TuristickiVodics.Where(t => t.TuristickiVodicId == id)
                .SingleOrDefault();
                
            TuristickiVodicDetaljiVM model = new TuristickiVodicDetaljiVM
            {
                TuristickiVodicId = x.TuristickiVodicId,
                Naziv = x.Naziv,
                StraniJezik = x.StraniJezik,
                CijenaVodicaPoDanu=x.CijenaVodicaPoDanu

               
            };
            return View("DetaljiTuristickiVodic", model);
        }
        public IActionResult UrediTuristickiVodic(TuristickiVodicDetaljiVM input)
        {
            TuristickiVodic x = _context.TuristickiVodics.Where(t => t.TuristickiVodicId == input.TuristickiVodicId)
                .SingleOrDefault();


            x.Naziv = input.Naziv;
            x.StraniJezik = input.StraniJezik;
            x.CijenaVodicaPoDanu = input.CijenaVodicaPoDanu;


            
            _context.TuristickiVodics.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult DodajTuristickogVodica()
        {
            TuristickiVodicDodajVM ulazniModel = new TuristickiVodicDodajVM();
           
            return View("DodajTuristickogVodica", ulazniModel);
        }
        public IActionResult SnimiTuristickogVodica(TuristickiVodicDodajVM input)
        {

            TuristickiVodic trv = new TuristickiVodic
            {
                TuristickiVodicId=input.TuristickiVodicId,
                Naziv = input.Naziv,
                StraniJezik = input.StraniJezik,
                CijenaVodicaPoDanu=input.CijenaVodicaPoDanu
            };
           
            _context.TuristickiVodics.Add(trv);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ObrisiTuristickogVodica(int id)
        {
            TuristickiVodic x = _context.TuristickiVodics.Find(id);
            _context.TuristickiVodics.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
       
    }
}