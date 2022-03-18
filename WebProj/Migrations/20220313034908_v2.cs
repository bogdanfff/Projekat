using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProj.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "Predmet",
                newName: "Naziv");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Predmet",
                newName: "Ime");
        }
    }
}
