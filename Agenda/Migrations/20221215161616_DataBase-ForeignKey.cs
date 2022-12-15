using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Migrations
{
    public partial class DataBaseForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idUser",
                table: "Contactos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_idUser",
                table: "Contactos",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_AspNetUsers_idUser",
                table: "Contactos",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_AspNetUsers_idUser",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_idUser",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Contactos");
        }
    }
}
