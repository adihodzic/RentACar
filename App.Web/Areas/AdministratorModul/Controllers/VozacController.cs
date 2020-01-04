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

    public class VozacController : Controller
    {
        private MojContext _context;
        public VozacController(MojContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            VozacIndexVM model = new VozacIndexVM
            {
                rowsV = _context.Vozacs
                .Select(x => new VozacIndexVM.RowV
                {
                    VozacId=x.VozacId,
                    Naziv = x.Naziv,
                    CijenaVozacaPoDanu=x.CijenaVozacaPoDanu
                     
                   
                }).ToList(),


            };
            return View("Index", model);
        }

        public IActionResult DetaljiVozac(int id)
        {
            Vozac x = _context.Vozacs.Where(v => v.VozacId == id)
                .SingleOrDefault();

            VozacDetaljiVM model = new VozacDetaljiVM
            {
                VozacId=x.VozacId,
                Naziv = x.Naziv,
                CijenaVozacaPoDanu=x.CijenaVozacaPoDanu,


                

            };
            return View("DetaljiVozac", model);
        }
        public IActionResult UrediVozac(VozacDetaljiVM input)
        {
            Vozac x = _context.Vozacs.Where(v => v.VozacId == input.VozacId)
                
                .SingleOrDefault();


            x.VozacId = input.VozacId;
            x.Naziv = input.Naziv;
            x.CijenaVozacaPoDanu = input.CijenaVozacaPoDanu;

            
            _context.Vozacs.Update(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Vozac");
        }
        public IActionResult DodajVozaca()
        {
            VozacDodajVM ulazniModel = new VozacDodajVM();
           
            return View("DodajVozaca", ulazniModel);
        }
        public IActionResult SnimiVozaca(VozacDodajVM input)
        {

            Vozac vzc = new Vozac
            {
                VozacId=input.VozacId,
                Naziv = input.Naziv,
                CijenaVozacaPoDanu = input.CijenaVozacaPoDanu
                

            };
           
            _context.Vozacs.Add(vzc);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ObrisiVozaca(int id)
        {
            Vozac x = _context.Vozacs.Find(id);
            _context.Vozacs.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
       
    }
}