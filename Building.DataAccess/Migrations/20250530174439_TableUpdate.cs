using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenditureId",
                table: "ExpenditureDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureDetails_ExpenseId",
                table: "ExpenditureDetails",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenseId",
                table: "ExpenditureDetails",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenseId",
                table: "ExpenditureDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExpenditureDetails_ExpenseId",
                table: "ExpenditureDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenditureId",
                table: "ExpenditureDetails",
                column: "ExpenditureId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
