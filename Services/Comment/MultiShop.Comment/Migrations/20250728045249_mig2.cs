using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Comment.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserComments");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserComments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
