using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class orderbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_order_tbl_book_SelectedBookBook_Id",
                table: "tbl_order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_order_SelectedBookBook_Id",
                table: "tbl_order");

            migrationBuilder.DropColumn(
                name: "OrderLastName",
                table: "tbl_order");

            migrationBuilder.DropColumn(
                name: "Order_Address",
                table: "tbl_order");

            migrationBuilder.DropColumn(
                name: "Order_Email",
                table: "tbl_order");

            migrationBuilder.RenameColumn(
                name: "SelectedBookBook_Id",
                table: "tbl_order",
                newName: "Book_Id");

            migrationBuilder.RenameColumn(
                name: "Order_ZipCode",
                table: "tbl_order",
                newName: "PaymentOption");

            migrationBuilder.RenameColumn(
                name: "Order_TotalCost",
                table: "tbl_order",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Order_Region",
                table: "tbl_order",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Order_PaymentMethod",
                table: "tbl_order",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "Order_Number",
                table: "tbl_order",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "Order_Name",
                table: "tbl_order",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "tbl_order",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentOption",
                table: "tbl_order",
                newName: "Order_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_order",
                newName: "Order_TotalCost");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tbl_order",
                newName: "Order_Region");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "tbl_order",
                newName: "Order_PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "tbl_order",
                newName: "Order_Number");

            migrationBuilder.RenameColumn(
                name: "Book_Id",
                table: "tbl_order",
                newName: "SelectedBookBook_Id");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "tbl_order",
                newName: "Order_Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_order",
                newName: "Order_Id");

            migrationBuilder.AddColumn<string>(
                name: "OrderLastName",
                table: "tbl_order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Order_Address",
                table: "tbl_order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Order_Email",
                table: "tbl_order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_SelectedBookBook_Id",
                table: "tbl_order",
                column: "SelectedBookBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_order_tbl_book_SelectedBookBook_Id",
                table: "tbl_order",
                column: "SelectedBookBook_Id",
                principalTable: "tbl_book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
