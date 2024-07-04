using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class new_orderinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_order",
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
                    Order_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order", x => x.Order_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_order");
        }
    }
}
