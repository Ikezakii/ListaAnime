using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaAnime.Migrations
{
    /// <inheritdoc />
    public partial class TabelaSeasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temporada",
                table: "Animes");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemporadaId",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_TemporadaId",
                table: "Animes",
                column: "TemporadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Seasons_TemporadaId",
                table: "Animes",
                column: "TemporadaId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Seasons_TemporadaId",
                table: "Animes");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Animes_TemporadaId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "TemporadaId",
                table: "Animes");

            migrationBuilder.AddColumn<string>(
                name: "Temporada",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
