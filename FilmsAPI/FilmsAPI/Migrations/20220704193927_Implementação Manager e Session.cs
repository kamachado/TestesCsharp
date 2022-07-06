using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsAPI.Migrations
{
    public partial class ImplementaçãoManagereSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classification",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_ManagerId",
                table: "Cinemas",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_CinemaId",
                table: "Session",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_FilmId",
                table: "Session",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Manager_ManagerId",
                table: "Cinemas",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Manager_ManagerId",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_ManagerId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Cinemas");
        }
    }
}
