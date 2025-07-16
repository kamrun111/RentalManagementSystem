using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenantTableStatusFieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StatusId",
                table: "Tenants",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Statuses_StatusId",
                table: "Tenants",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Statuses_StatusId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StatusId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tenants");
        }
    }
}
