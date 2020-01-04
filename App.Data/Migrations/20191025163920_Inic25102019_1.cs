using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class Inic25102019_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CijenaRutePoDanu",
                table: "Rezervacijas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaVodicaPoDanu",
                table: "Rezervacijas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaVozacaPoDanu",
                table: "Rezervacijas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaVozilaPoDanu",
                table: "Rezervacijas",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaRutePoDanu",
                table: "Rezervacijas");

            migrationBuilder.DropColumn(
                name: "CijenaVodicaPoDanu",
                table: "Rezervacijas");

            migrationBuilder.DropColumn(
                name: "CijenaVozacaPoDanu",
                table: "Rezervacijas");

            migrationBuilder.DropColumn(
                name: "CijenaVozilaPoDanu",
                table: "Rezervacijas");
        }
    }
}
