using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pryPlayers.DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plaPLAtPlayer",
                columns: table => new
                {
                    PLAid_player = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PLAname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PLAlastname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PLApuntaje = table.Column<int>(type: "int", nullable: false),
                    PLAnivel = table.Column<short>(type: "smallint", nullable: false),
                    PLAcelular = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PLAfecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLAfecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLAestado = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plaPLAtPlayer", x => x.PLAid_player);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plaPLAtPlayer_PLAid_player",
                table: "plaPLAtPlayer",
                column: "PLAid_player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plaPLAtPlayer");
        }
    }
}
