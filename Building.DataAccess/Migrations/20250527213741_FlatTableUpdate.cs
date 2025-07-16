using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FlatTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FlatRent",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceCharge",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                columns: new[] { "FlatRent", "ServiceCharge" },
                values: new object[] { 10000m, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                columns: new[] { "FlatRent", "ServiceCharge" },
                values: new object[] { 20000m, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                columns: new[] { "FlatRent", "ServiceCharge" },
                values: new object[] { 25000m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceCharge",
                table: "Flats");

            migrationBuilder.AlterColumn<double>(
                name: "FlatRent",
                table: "Flats",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                column: "FlatRent",
                value: 10000.0);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                column: "FlatRent",
                value: 20000.0);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                column: "FlatRent",
                value: 25000.0);
        }
    }
}
