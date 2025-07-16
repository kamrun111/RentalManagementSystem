using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StatusTableAdd : Migration
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

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StatusId",
                table: "Tenants",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Status_StatusId",
                table: "Tenants",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Status_StatusId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StatusId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tenants");
        }
    }
}
