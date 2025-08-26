using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class flatTableUpdateProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Floors_FloorId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServiceCharge",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Flats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Flats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlatTypeId",
                table: "Flats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FlatRent",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { 0, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId",
                principalTable: "FlatTypes",
                principalColumn: "FlatTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Floors_FloorId",
                table: "Flats",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "FloorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Floors_FloorId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServiceCharge",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FlatTypeId",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "FlatRent",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { null, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { null, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                columns: new[] { "LocationId", "ServiceCharge" },
                values: new object[] { null, 0m });

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId",
                principalTable: "FlatTypes",
                principalColumn: "FlatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Floors_FloorId",
                table: "Flats",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Locations_LocationId",
                table: "Flats",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }
    }
}
