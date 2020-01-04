using App.Data;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web.Helper
{
    public  class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool administrator, bool radnik, bool klijent)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { administrator, radnik, klijent };
        }

    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool administrator, bool radnik, bool klijent)
        {
            _administrator = administrator;
            _radnik = radnik;
            _klijent = klijent;
        }
        private readonly bool _administrator;
        private readonly bool _radnik;
        private readonly bool _klijent;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            KorisnickiNalog k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Nemate pravo pristupa";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { area = "" });
                return;
            }

            MojContext db = filterContext.HttpContext.RequestServices.GetService<MojContext>();

            if (_administrator && db.Administrators.Any(s => s.KorisnickiNalogId == k.KorisnickiNalogId))
            {
                await next(); //OK ima pravo pristupa
                return;
            }

            if (_radnik && db.Radniks.Any(s => s.KorisnickiNalogId == k.KorisnickiNalogId))
            {
                await next(); //OK ima pravo pristupa
                return;
            }

            if (_klijent && db.Klijents.Any(s => s.KorisnickiNalogId == k.KorisnickiNalogId))
            {
                await next(); //OK ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"]="Nemate pravo pristupa!"; //OK ima pravo pristupa
            }
            
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { area = "" });
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { 
        
        }
    }
    
}
