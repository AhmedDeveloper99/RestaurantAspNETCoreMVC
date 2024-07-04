using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAspNETCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class addnulableinBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_Cost",
                table: "tbl_buybook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Book_Cost",
                table: "tbl_book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Cost",
                table: "tbl_buybook");

            migrationBuilder.AlterColumn<string>(
                name: "Book_Cost",
                table: "tbl_book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
