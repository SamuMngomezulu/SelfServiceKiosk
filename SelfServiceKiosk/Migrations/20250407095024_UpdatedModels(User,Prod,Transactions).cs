using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfServiceKiosk.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelsUserProdTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "TransactionAmount");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "ProductDescription");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TransactionAmount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Products",
                newName: "Description");
        }
    }
}
