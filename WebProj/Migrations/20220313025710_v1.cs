using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProj.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzej",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzej", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePosetioca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrezimePosetioca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MuzejID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Karta_Muzej_MuzejID",
                        column: x => x.MuzejID,
                        principalTable: "Muzej",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Godina = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    MuzejID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Predmet_Muzej_MuzejID",
                        column: x => x.MuzejID,
                        principalTable: "Muzej",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_MuzejID",
                table: "Karta",
                column: "MuzejID");

            migrationBuilder.CreateIndex(
                name: "IX_Predmet_MuzejID",
                table: "Predmet",
                column: "MuzejID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "Muzej");
        }
    }
}
