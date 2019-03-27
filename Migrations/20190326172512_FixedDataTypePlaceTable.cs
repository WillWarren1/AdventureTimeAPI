using Microsoft.EntityFrameworkCore.Migrations;

namespace adventuretimeapi.Migrations
{
    public partial class FixedDataTypePlaceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "typeOfGovernment",
                table: "Places",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "typeOfGovernment",
                table: "Places",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
