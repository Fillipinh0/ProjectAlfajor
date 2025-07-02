using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAlfajor.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCustomers",
                columns: table => new
                {
                    CreditCustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AmountOwed = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCustomers", x => x.CreditCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DailySales",
                columns: table => new
                {
                    DailySaleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantitySold = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityLeft = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalReceived = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySales", x => x.DailySaleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCustomers");

            migrationBuilder.DropTable(
                name: "DailySales");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
