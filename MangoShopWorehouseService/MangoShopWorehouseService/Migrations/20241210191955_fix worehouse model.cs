using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoShopWorehouseService.Migrations
{
    /// <inheritdoc />
    public partial class fixworehousemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneralProductName",
                table: "Worehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralProductName",
                table: "Worehouses");
        }
    }
}
