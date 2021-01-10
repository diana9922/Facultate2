using Microsoft.EntityFrameworkCore.Migrations;

namespace Facultate2.Migrations
{
    public partial class Migrare3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfesorPrenume",
                table: "Profesor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titlu",
                table: "Profesor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfesorPrenume",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "Titlu",
                table: "Profesor");
        }
    }
}
