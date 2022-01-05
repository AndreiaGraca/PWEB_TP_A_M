using Microsoft.EntityFrameworkCore.Migrations;

namespace PWEB_TP_A_M.Migrations
{
    public partial class ModelsAdministracaoAgendamentoAnalisesCentroTesteClientesGestoresLocalizacoesTecnicosTestes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnalise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeAnalise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTeste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeTeste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI = table.Column<int>(type: "int", nullable: false),
                    NIF = table.Column<int>(type: "int", nullable: false),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    AgendamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    AgendamentoId = table.Column<int>(type: "int", nullable: true)
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
                name: "Administracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Laboratorios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentrosTesteId = table.Column<int>(type: "int", nullable: false),
                    ClientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administracao_CentroTeste_CentrosTesteId",
                        column: x => x.CentrosTesteId,
                        principalTable: "CentroTeste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administracao_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAgendamentoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentroId = table.Column<int>(type: "int", nullable: false),
                    CentrosId = table.Column<int>(type: "int", nullable: true),
                    TestesId = table.Column<int>(type: "int", nullable: false),
                    AnaliseId = table.Column<int>(type: "int", nullable: false),
                    AnalisesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Analises_AnalisesId",
                        column: x => x.AnalisesId,
                        principalTable: "Analises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamento_CentroTeste_CentrosId",
                        column: x => x.CentrosId,
                        principalTable: "CentroTeste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamento_Testes_TestesId",
                        column: x => x.TestesId,
                        principalTable: "Testes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Administracao_CentrosTesteId",
                table: "Administracao",
                column: "CentrosTesteId");

            migrationBuilder.CreateIndex(
                name: "IX_Administracao_ClientesId",
                table: "Administracao",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AnalisesId",
                table: "Agendamento",
                column: "AnalisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_CentrosId",
                table: "Agendamento",
                column: "CentrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_TestesId",
                table: "Agendamento",
                column: "TestesId");

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
                name: "IX_Clientes_AgendamentoId",
                table: "Clientes",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_CentroTesteId",
                table: "Gestores",
                column: "CentroTesteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_AgendamentoId",
                table: "Tecnicos",
                column: "AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agendamento_AgendamentoId",
                table: "Clientes",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnicos_Agendamento_AgendamentoId",
                table: "Tecnicos",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_CentroTeste_CentrosId",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Administracao");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CentroTeste");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Analises");

            migrationBuilder.DropTable(
                name: "Testes");
        }
    }
}
