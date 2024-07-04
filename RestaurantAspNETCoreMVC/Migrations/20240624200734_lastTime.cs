using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class lastTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Order_TotalCost",
                table: "tbl_order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_TotalCost",
                table: "tbl_order");
        }
    }
}
