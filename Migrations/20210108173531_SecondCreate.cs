using Microsoft.EntityFrameworkCore.Migrations;

namespace Facultate2.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorID",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProfesorID",
                table: "Student",
                column: "ProfesorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Profesor_ProfesorID",
                table: "Student",
                column: "ProfesorID",
                principalTable: "Profesor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Profesor_ProfesorID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropIndex(
                name: "IX_Student_ProfesorID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProfesorID",
                table: "Student");
        }
    }
}
