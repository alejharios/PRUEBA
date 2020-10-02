using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba2.Migrations
{
    public partial class addinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trabajadores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    trabajadorId = table.Column<long>(nullable: true),
                    identificacion = table.Column<int>(nullable: false),
                    tipoindetificacion = table.Column<int>(nullable: false),
                    primernombre = table.Column<string>(nullable: true),
                    segundonombre = table.Column<string>(nullable: true),
                    primerapellido = table.Column<string>(nullable: true),
                    segundoapellido = table.Column<string>(nullable: true),
                    fechadenacimineto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contratos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerocontrato = table.Column<int>(nullable: false),
                    nombreentidad = table.Column<string>(nullable: true),
                    fechainicio = table.Column<DateTime>(nullable: false),
                    fechafin = table.Column<DateTime>(nullable: false),
                    trabajadoresId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contratos_trabajadores_trabajadoresId",
                        column: x => x.trabajadoresId,
                        principalTable: "trabajadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contratos_trabajadoresId",
                table: "contratos",
                column: "trabajadoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajadores_contratos_Id",
                table: "trabajadores",
                column: "Id",
                principalTable: "contratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratos_trabajadores_trabajadoresId",
                table: "contratos");

            migrationBuilder.DropTable(
                name: "trabajadores");

            migrationBuilder.DropTable(
                name: "contratos");
        }
    }
}
