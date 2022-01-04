using Microsoft.EntityFrameworkCore.Migrations;

namespace PWEB_TP_A_M.Migrations
{
    public partial class tp_am_m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo_analise",
                table: "CentroTeste");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo_analise",
                table: "CentroTeste",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
