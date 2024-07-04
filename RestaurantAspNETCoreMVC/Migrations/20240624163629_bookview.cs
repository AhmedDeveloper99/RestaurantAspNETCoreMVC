using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class bookview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_bookview",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bookview", x => x.Order_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bookview");
        }
    }
}
