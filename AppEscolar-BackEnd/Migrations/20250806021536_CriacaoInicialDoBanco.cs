using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppEscolar_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicialDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    TipoUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Usuario_id);
                    table.ForeignKey(
                        name: "FK_Admins_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Ra = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Creditos = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Usuario_Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TipoNoticia = table.Column<int>(type: "integer", nullable: false),
                    ImagemUrl = table.Column<string>(type: "text", nullable: false),
                    Autor = table.Column<string>(type: "text", nullable: false),
                    AutorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Admins_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Admins",
                        principalColumn: "Usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDoacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoUnico = table.Column<string>(type: "text", nullable: false),
                    ValorReais = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    FoiUsado = table.Column<bool>(type: "boolean", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataUso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlunoIdUso = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDoacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoDoacoes_Alunos_AlunoIdUso",
                        column: x => x.AlunoIdUso,
                        principalTable: "Alunos",
                        principalColumn: "Usuario_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoacoes_AlunoIdUso",
                table: "HistoricoDoacoes",
                column: "AlunoIdUso");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_AutorId",
                table: "Noticias",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoDoacoes");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
