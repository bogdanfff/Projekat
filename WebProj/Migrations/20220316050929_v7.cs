using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProj.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojRezervacije",
                table: "Karta",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojRezervacije",
                table: "Karta");
        }
    }
}
