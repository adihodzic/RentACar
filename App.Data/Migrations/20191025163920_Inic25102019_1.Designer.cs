﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20191025163920_Inic25102019_1")]
    partial class Inic25102019_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Data.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Email");

                    b.Property<int>("GradId");

                    b.Property<string>("ITCertifikat");

                    b.Property<string>("Ime");

                    b.Property<string>("IzjavaZastitaPodataka");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("AdministratorId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GradId");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("App.Data.Models.AutorizacijskiToken", b =>
                {
                    b.Property<int>("AutorizacijskiTokenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnickiNalogId");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.HasKey("AutorizacijskiTokenId");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutorizacijskiTokens");
                });

            modelBuilder.Entity("App.Data.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivDrzave");

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzavas");
                });

            modelBuilder.Entity("App.Data.Models.Grad", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivGrada");

                    b.HasKey("GradId");

                    b.ToTable("Grads");
                });

            modelBuilder.Entity("App.Data.Models.Klijent", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("BrLK");

                    b.Property<string>("BrojPasosa");

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Email");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("KlijentId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GradId");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Klijents");
                });

            modelBuilder.Entity("App.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("KorisnickiNalogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<bool>("ZapamtiLozinku");

                    b.HasKey("KorisnickiNalogId");

                    b.ToTable("KorisnickiNalogs");
                });

            modelBuilder.Entity("App.Data.Models.MarkaVozila", b =>
                {
                    b.Property<int>("MarkaVozilaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivMarke");

                    b.HasKey("MarkaVozilaId");

                    b.ToTable("MarkaVozilas");
                });

            modelBuilder.Entity("App.Data.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("NacinPlacanjaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("NacinPlacanjaId");

                    b.ToTable("NacinPlacanjas");
                });

            modelBuilder.Entity("App.Data.Models.Radnik", b =>
                {
                    b.Property<int>("RadnikId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Email");

                    b.Property<int>("GodineStaza");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Pozicija");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("RadnikId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GradId");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Radniks");
                });

            modelBuilder.Entity("App.Data.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojRacuna");

                    b.Property<double>("CijenaRutePoDanu");

                    b.Property<double>("CijenaUslugePoDanu");

                    b.Property<double>("CijenaVodicaPoDanu");

                    b.Property<double>("CijenaVozacaPoDanu");

                    b.Property<double>("CijenaVozilaPoDanu");

                    b.Property<DateTime>("DatumPreuzimanja");

                    b.Property<DateTime>("DatumRacuna");

                    b.Property<DateTime>("DatumVracanja");

                    b.Property<int>("KlijentId");

                    b.Property<int>("NacinPlacanjaId");

                    b.Property<int>("TuristRutaId");

                    b.Property<int?>("TuristickiVodicId");

                    b.Property<double>("UkupnaCijena");

                    b.Property<int>("VozacId");

                    b.Property<int>("VoziloId");

                    b.HasKey("RezervacijaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("NacinPlacanjaId");

                    b.HasIndex("TuristRutaId");

                    b.HasIndex("TuristickiVodicId");

                    b.HasIndex("VozacId");

                    b.HasIndex("VoziloId");

                    b.ToTable("Rezervacijas");
                });

            modelBuilder.Entity("App.Data.Models.TipVozila", b =>
                {
                    b.Property<int>("TipVozilaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivTipa");

                    b.HasKey("TipVozilaId");

                    b.ToTable("TipVozilas");
                });

            modelBuilder.Entity("App.Data.Models.TuristickiVodic", b =>
                {
                    b.Property<int>("TuristickiVodicId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CijenaVodicaPoDanu");

                    b.Property<string>("Naziv");

                    b.Property<string>("StraniJezik");

                    b.HasKey("TuristickiVodicId");

                    b.ToTable("TuristickiVodics");
                });

            modelBuilder.Entity("App.Data.Models.TuristRuta", b =>
                {
                    b.Property<int>("TuristRutaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CijenaTuristRutePoDanu");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("TuristRutaId");

                    b.ToTable("TuristRutas");
                });

            modelBuilder.Entity("App.Data.Models.Vozac", b =>
                {
                    b.Property<int>("VozacId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CijenaVozacaPoDanu");

                    b.Property<string>("Naziv");

                    b.Property<int>("RadnikId");

                    b.HasKey("VozacId");

                    b.HasIndex("RadnikId");

                    b.ToTable("Vozacs");
                });

            modelBuilder.Entity("App.Data.Models.Vozilo", b =>
                {
                    b.Property<int>("VoziloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boja");

                    b.Property<string>("BrojMotora");

                    b.Property<int>("BrojSjedista");

                    b.Property<int>("BrojVrata");

                    b.Property<double>("CijenaVozilaPoDanu");

                    b.Property<DateTime>("DatumIstekaRegistracije");

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<DateTime>("GodinaProizvodnje");

                    b.Property<bool>("Ispravnost");

                    b.Property<int>("MarkaVozilaId");

                    b.Property<string>("NazivVozila");

                    b.Property<string>("PhotoPath");

                    b.Property<double>("PredjeniKilometri");

                    b.Property<int>("RadnikId");

                    b.Property<string>("RegOznaka");

                    b.Property<int>("TipVozilaId");

                    b.Property<int>("VrstaGorivaId");

                    b.HasKey("VoziloId");

                    b.HasIndex("MarkaVozilaId");

                    b.HasIndex("RadnikId");

                    b.HasIndex("TipVozilaId");

                    b.HasIndex("VrstaGorivaId");

                    b.ToTable("Vozilos");
                });

            modelBuilder.Entity("App.Data.Models.VrstaGoriva", b =>
                {
                    b.Property<int>("VrstaGorivaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivGoriva");

                    b.HasKey("VrstaGorivaId");

                    b.ToTable("VrstaGorivas");
                });

            modelBuilder.Entity("App.Data.Models.Administrator", b =>
                {
                    b.HasOne("App.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("App.Data.Models.AutorizacijskiToken", b =>
                {
                    b.HasOne("App.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Data.Models.Klijent", b =>
                {
                    b.HasOne("App.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("App.Data.Models.Radnik", b =>
                {
                    b.HasOne("App.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("App.Data.Models.Rezervacija", b =>
                {
                    b.HasOne("App.Data.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanjaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.TuristRuta", "TuristRuta")
                        .WithMany()
                        .HasForeignKey("TuristRutaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.TuristickiVodic", "TuristickiVodic")
                        .WithMany()
                        .HasForeignKey("TuristickiVodicId");

                    b.HasOne("App.Data.Models.Vozac", "Vozac")
                        .WithMany()
                        .HasForeignKey("VozacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Data.Models.Vozac", b =>
                {
                    b.HasOne("App.Data.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Data.Models.Vozilo", b =>
                {
                    b.HasOne("App.Data.Models.MarkaVozila", "MarkaVozila")
                        .WithMany()
                        .HasForeignKey("MarkaVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.TipVozila", "TipVozila")
                        .WithMany()
                        .HasForeignKey("TipVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Data.Models.VrstaGoriva", "VrstaGoriva")
                        .WithMany()
                        .HasForeignKey("VrstaGorivaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
