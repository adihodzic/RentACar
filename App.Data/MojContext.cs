using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Data
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions<MojContext> x) : base(x)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Drzava> Drzavas { get; set; }
        public DbSet<Grad> Grads { get; set; }
        public DbSet<Klijent> Klijents { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalogs { get; set; }
        public DbSet<MarkaVozila> MarkaVozilas { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanjas { get; set; }
        public DbSet<Radnik> Radniks { get; set; }
        public DbSet<Rezervacija> Rezervacijas { get; set; }
        public DbSet<TipVozila> TipVozilas { get; set; }
        public DbSet<TuristickiVodic> TuristickiVodics { get; set; }
        public DbSet<TuristRuta> TuristRutas { get; set; }
        public DbSet<Vozac> Vozacs { get; set; }
        public DbSet<Vozilo> Vozilos { get; set; }
        public DbSet<VrstaGoriva> VrstaGorivas { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiTokens { get; set; }

    }
}