using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAlfajor.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityAndTotalValue_RenamePurchasePriceToUnitPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPurchaseValue",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalPurchaseValue",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "PurchasePrice");
        }
    }
}
