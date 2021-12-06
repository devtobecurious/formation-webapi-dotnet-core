using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfieAWookies.Core.Selfies.Data.Migrations.Migrations
{
    public partial class AddSurnameWookie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Wookie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Wookie");
        }
    }
}
