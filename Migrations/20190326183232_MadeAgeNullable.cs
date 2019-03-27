using Microsoft.EntityFrameworkCore.Migrations;

namespace adventuretimeapi.Migrations
{
    public partial class MadeAgeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
