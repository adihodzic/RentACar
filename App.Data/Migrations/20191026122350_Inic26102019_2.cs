using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class Inic26102019_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacijas_TuristickiVodics_TuristickiVodicId",
                table: "Rezervacijas");

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

            migrationBuilder.AlterColumn<int>(
                name: "TuristickiVodicId",
                table: "Rezervacijas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacijas_TuristickiVodics_TuristickiVodicId",
                table: "Rezervacijas",
                column: "TuristickiVodicId",
                principalTable: "TuristickiVodics",
                principalColumn: "TuristickiVodicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacijas_TuristickiVodics_TuristickiVodicId",
                table: "Rezervacijas");

            migrationBuilder.AlterColumn<int>(
                name: "TuristickiVodicId",
                table: "Rezervacijas",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacijas_TuristickiVodics_TuristickiVodicId",
                table: "Rezervacijas",
                column: "TuristickiVodicId",
                principalTable: "TuristickiVodics",
                principalColumn: "TuristickiVodicId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
