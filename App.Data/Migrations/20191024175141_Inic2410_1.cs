using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class Inic2410_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzavas",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivDrzave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzavas", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Grads",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivGrada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grads", x => x.GradId);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalogs",
                columns: table => new
                {
                    KorisnickiNalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    ZapamtiLozinku = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalogs", x => x.KorisnickiNalogId);
                });

            migrationBuilder.CreateTable(
                name: "MarkaVozilas",
                columns: table => new
                {
                    MarkaVozilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivMarke = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaVozilas", x => x.MarkaVozilaId);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanjas",
                columns: table => new
                {
                    NacinPlacanjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanjas", x => x.NacinPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "TipVozilas",
                columns: table => new
                {
                    TipVozilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivTipa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipVozilas", x => x.TipVozilaId);
                });

            migrationBuilder.CreateTable(
                name: "TuristickiVodics",
                columns: table => new
                {
                    TuristickiVodicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    StraniJezik = table.Column<string>(nullable: true),
                    CijenaVodicaPoDanu = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristickiVodics", x => x.TuristickiVodicId);
                });

            migrationBuilder.CreateTable(
                name: "TuristRutas",
                columns: table => new
                {
                    TuristRutaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    CijenaTuristRutePoDanu = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristRutas", x => x.TuristRutaId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaGorivas",
                columns: table => new
                {
                    VrstaGorivaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivGoriva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaGorivas", x => x.VrstaGorivaId);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    ITCertifikat = table.Column<string>(nullable: true),
                    IzjavaZastitaPodataka = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false),
                    DrzavaId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrators_Drzavas_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzavas",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrators_Grads_GradId",
                        column: x => x.GradId,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrators_KorisnickiNalogs_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalogs",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijskiTokens",
                columns: table => new
                {
                    AutorizacijskiTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrijednost = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiTokens", x => x.AutorizacijskiTokenId);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiTokens_KorisnickiNalogs_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalogs",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijents",
                columns: table => new
                {
                    KlijentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    BrojPasosa = table.Column<string>(nullable: true),
                    BrLK = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false),
                    DrzavaId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijents", x => x.KlijentId);
                    table.ForeignKey(
                        name: "FK_Klijents_Drzavas_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzavas",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijents_Grads_GradId",
                        column: x => x.GradId,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijents_KorisnickiNalogs_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalogs",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Radniks",
                columns: table => new
                {
                    RadnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Pozicija = table.Column<string>(nullable: true),
                    GodineStaza = table.Column<int>(nullable: false),
                    GradId = table.Column<int>(nullable: false),
                    DrzavaId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radniks", x => x.RadnikId);
                    table.ForeignKey(
                        name: "FK_Radniks_Drzavas_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzavas",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Radniks_Grads_GradId",
                        column: x => x.GradId,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Radniks_KorisnickiNalogs_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalogs",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozacs",
                columns: table => new
                {
                    VozacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    CijenaVozacaPoDanu = table.Column<double>(nullable: false),
                    RadnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozacs", x => x.VozacId);
                    table.ForeignKey(
                        name: "FK_Vozacs_Radniks_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radniks",
                        principalColumn: "RadnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozilos",
                columns: table => new
                {
                    VoziloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivVozila = table.Column<string>(nullable: true),
                    GodinaProizvodnje = table.Column<DateTime>(nullable: false),
                    BrojMotora = table.Column<string>(nullable: true),
                    PredjeniKilometri = table.Column<double>(nullable: false),
                    BrojSjedista = table.Column<int>(nullable: false),
                    Boja = table.Column<string>(nullable: true),
                    BrojVrata = table.Column<int>(nullable: false),
                    RegOznaka = table.Column<string>(nullable: true),
                    CijenaVozilaPoDanu = table.Column<double>(nullable: false),
                    Ispravnost = table.Column<bool>(nullable: false),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    DatumIstekaRegistracije = table.Column<DateTime>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    TipVozilaId = table.Column<int>(nullable: false),
                    MarkaVozilaId = table.Column<int>(nullable: false),
                    VrstaGorivaId = table.Column<int>(nullable: false),
                    RadnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilos", x => x.VoziloId);
                    table.ForeignKey(
                        name: "FK_Vozilos_MarkaVozilas_MarkaVozilaId",
                        column: x => x.MarkaVozilaId,
                        principalTable: "MarkaVozilas",
                        principalColumn: "MarkaVozilaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilos_Radniks_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radniks",
                        principalColumn: "RadnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilos_TipVozilas_TipVozilaId",
                        column: x => x.TipVozilaId,
                        principalTable: "TipVozilas",
                        principalColumn: "TipVozilaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilos_VrstaGorivas_VrstaGorivaId",
                        column: x => x.VrstaGorivaId,
                        principalTable: "VrstaGorivas",
                        principalColumn: "VrstaGorivaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacijas",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPreuzimanja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: false),
                    CijenaUslugePoDanu = table.Column<double>(nullable: false),
                    BrojRacuna = table.Column<string>(nullable: true),
                    UkupnaCijena = table.Column<double>(nullable: false),
                    DatumRacuna = table.Column<DateTime>(nullable: false),
                    NacinPlacanjaId = table.Column<int>(nullable: false),
                    VozacId = table.Column<int>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false),
                    TuristickiVodicId = table.Column<int>(nullable: true),
                    TuristRutaId = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacijas", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_Klijents_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijents",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_NacinPlacanjas_NacinPlacanjaId",
                        column: x => x.NacinPlacanjaId,
                        principalTable: "NacinPlacanjas",
                        principalColumn: "NacinPlacanjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_TuristRutas_TuristRutaId",
                        column: x => x.TuristRutaId,
                        principalTable: "TuristRutas",
                        principalColumn: "TuristRutaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_TuristickiVodics_TuristickiVodicId",
                        column: x => x.TuristickiVodicId,
                        principalTable: "TuristickiVodics",
                        principalColumn: "TuristickiVodicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_Vozacs_VozacId",
                        column: x => x.VozacId,
                        principalTable: "Vozacs",
                        principalColumn: "VozacId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_Vozilos_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilos",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_DrzavaId",
                table: "Administrators",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_GradId",
                table: "Administrators",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_KorisnickiNalogId",
                table: "Administrators",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiTokens_KorisnickiNalogId",
                table: "AutorizacijskiTokens",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijents_DrzavaId",
                table: "Klijents",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijents_GradId",
                table: "Klijents",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijents_KorisnickiNalogId",
                table: "Klijents",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_DrzavaId",
                table: "Radniks",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_GradId",
                table: "Radniks",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_KorisnickiNalogId",
                table: "Radniks",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_KlijentId",
                table: "Rezervacijas",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_NacinPlacanjaId",
                table: "Rezervacijas",
                column: "NacinPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_TuristRutaId",
                table: "Rezervacijas",
                column: "TuristRutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_TuristickiVodicId",
                table: "Rezervacijas",
                column: "TuristickiVodicId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_VozacId",
                table: "Rezervacijas",
                column: "VozacId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_VoziloId",
                table: "Rezervacijas",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozacs_RadnikId",
                table: "Vozacs",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilos_MarkaVozilaId",
                table: "Vozilos",
                column: "MarkaVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilos_RadnikId",
                table: "Vozilos",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilos_TipVozilaId",
                table: "Vozilos",
                column: "TipVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilos_VrstaGorivaId",
                table: "Vozilos",
                column: "VrstaGorivaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AutorizacijskiTokens");

            migrationBuilder.DropTable(
                name: "Rezervacijas");

            migrationBuilder.DropTable(
                name: "Klijents");

            migrationBuilder.DropTable(
                name: "NacinPlacanjas");

            migrationBuilder.DropTable(
                name: "TuristRutas");

            migrationBuilder.DropTable(
                name: "TuristickiVodics");

            migrationBuilder.DropTable(
                name: "Vozacs");

            migrationBuilder.DropTable(
                name: "Vozilos");

            migrationBuilder.DropTable(
                name: "MarkaVozilas");

            migrationBuilder.DropTable(
                name: "Radniks");

            migrationBuilder.DropTable(
                name: "TipVozilas");

            migrationBuilder.DropTable(
                name: "VrstaGorivas");

            migrationBuilder.DropTable(
                name: "Drzavas");

            migrationBuilder.DropTable(
                name: "Grads");

            migrationBuilder.DropTable(
                name: "KorisnickiNalogs");
        }
    }
}
