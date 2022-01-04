using Microsoft.EntityFrameworkCore.Migrations;

namespace PWEB_TP_A_M.Migrations
{
    public partial class ModelsClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Laboratorios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo_Postal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroTeste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    Tipo_analise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimTestes = table.Column<int>(type: "int", nullable: false),
                    Tecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalisesId = table.Column<int>(type: "int", nullable: false),
                    LocalidadeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizacoesId = table.Column<int>(type: "int", nullable: true),
                    TecnicosId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicosId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroTeste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroTeste_Analises_AnalisesId",
                        column: x => x.AnalisesId,
                        principalTable: "Analises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentroTeste_Localizacoes_LocalizacoesId",
                        column: x => x.LocalizacoesId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CentroTeste_Tecnicos_TecnicosId1",
                        column: x => x.TecnicosId1,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentroId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentroTesteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gestores_CentroTeste_CentroTesteId",
                        column: x => x.CentroTesteId,
                        principalTable: "CentroTeste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroTeste_AnalisesId",
                table: "CentroTeste",
                column: "AnalisesId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroTeste_LocalizacoesId",
                table: "CentroTeste",
                column: "LocalizacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroTeste_TecnicosId1",
                table: "CentroTeste",
                column: "TecnicosId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_CentroTesteId",
                table: "Gestores",
                column: "CentroTesteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administracao");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "CentroTeste");

            migrationBuilder.DropTable(
                name: "Analises");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Tecnicos");
        }
    }
}
