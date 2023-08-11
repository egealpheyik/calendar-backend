using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginPage.DataAccess.Migrations
{
    public partial class updatedv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Importance",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Importance",
                table: "Events",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
