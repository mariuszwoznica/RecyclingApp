using Microsoft.EntityFrameworkCore.Migrations;

namespace RecyclingApp.Infrastructure.Migrations
{
    public partial class AddEnumToOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "text",
                nullable: true);
        }
    }
}
