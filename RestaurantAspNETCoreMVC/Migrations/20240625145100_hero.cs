using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class hero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Cost",
                table: "tbl_buybook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_Cost",
                table: "tbl_buybook",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
