using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationToFlat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                column: "LocationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                column: "LocationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                column: "LocationId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_LocationId",
                table: "Flats",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_LocationId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Flats");
        }
    }
}
