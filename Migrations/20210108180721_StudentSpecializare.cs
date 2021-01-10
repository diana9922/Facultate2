using Microsoft.EntityFrameworkCore.Migrations;

namespace Facultate2.Migrations
{
    public partial class StudentSpecializare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializareNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentSpecializare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    SpecializareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSpecializare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentSpecializare_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSpecializare_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSpecializare_SpecializareID",
                table: "StudentSpecializare",
                column: "SpecializareID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSpecializare_StudentID",
                table: "StudentSpecializare",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSpecializare");

            migrationBuilder.DropTable(
                name: "Specializare");
        }
    }
}
