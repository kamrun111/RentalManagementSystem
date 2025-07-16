using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetFlatStatusDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlatStatus",
                table: "Flats",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                column: "FlatStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                column: "FlatStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                column: "FlatStatus",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlatStatus",
                table: "Flats");
        }
    }
}
