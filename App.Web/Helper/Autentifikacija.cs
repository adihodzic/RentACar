using App.Data;
using App.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik, bool SnimiUCookie = false)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);

            if (SnimiUCookie)
            {
                MojContext db = context.RequestServices.GetService<MojContext>();

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiTokens.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnickiNalogId = korisnik.KorisnickiNalogId,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
            else
            {
                context.Response.SetCookieJson(LogiraniKorisnik, null);
            }
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            KorisnickiNalog korisnik = context.Session.Get<KorisnickiNalog>(LogiraniKorisnik);
            if (korisnik == null)
            {
                MojContext db = context.RequestServices.GetService<MojContext>();

                string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);

                if (token == null)
                    return null;

                korisnik = db.AutorizacijskiTokens
                    .Where(x => x.Vrijednost == token)
                    .Select(s => s.KorisnickiNalog)
                    .SingleOrDefault();

               
            }
            if (korisnik != null)
            {
                context.Session.Set(LogiraniKorisnik, korisnik);
            }
            return korisnik;
        }
            
    }
}
