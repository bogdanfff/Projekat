using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProj.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrezimePosetioca",
                table: "Karta",
                newName: "Prezime");

            migrationBuilder.RenameColumn(
                name: "ImePosetioca",
                table: "Karta",
                newName: "Ime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "Karta",
                newName: "PrezimePosetioca");

            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "Karta",
                newName: "ImePosetioca");
        }
    }
}
