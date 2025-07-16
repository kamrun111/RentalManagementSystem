using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExpedtitureTableLocationIdAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovedBy",
                table: "Expenditures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Expenditures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_LocationId",
                table: "Expenditures",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Locations_LocationId",
                table: "Expenditures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Locations_LocationId",
                table: "Expenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_LocationId",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Expenditures");
        }
    }
}
