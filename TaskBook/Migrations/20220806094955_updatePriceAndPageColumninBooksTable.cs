using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskBook.Migrations
{
    public partial class updatePriceAndPageColumninBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Page",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Page",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
