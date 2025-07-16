using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExpenditureAmountUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpenditureInvoice",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ExpenditureDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "ExpenditureDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ExpenditureDetails");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "ExpenditureDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenditureInvoice",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
