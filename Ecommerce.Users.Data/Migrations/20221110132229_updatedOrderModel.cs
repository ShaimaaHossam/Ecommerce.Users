using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Users.Data.Migrations
{
    public partial class updatedOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressLine3",
                table: "Order",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Order",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Order",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Order",
                newName: "AddressLine3");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Order",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Order",
                newName: "AddressLine1");
        }
    }
}
