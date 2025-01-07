using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoShopBasketService.Migrations
{
    /// <inheritdoc />
    public partial class deleteIsChecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Baskets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
