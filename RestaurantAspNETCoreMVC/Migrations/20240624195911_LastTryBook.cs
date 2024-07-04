using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class LastTryBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bookview");

            migrationBuilder.AddColumn<int>(
                name: "SelectedBookBook_Id",
                table: "tbl_order",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_order_tbl_book_SelectedBookBook_Id",
                table: "tbl_order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_order_SelectedBookBook_Id",
                table: "tbl_order");

            migrationBuilder.DropColumn(
                name: "SelectedBookBook_Id",
                table: "tbl_order");

            migrationBuilder.CreateTable(
                name: "tbl_bookview",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bookview", x => x.Order_Id);
                });
        }
    }
}
