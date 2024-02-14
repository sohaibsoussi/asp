using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_s7.Data.Migrations
{
    public partial class link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HorsePictureLink",
                table: "Horses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorsePictureLink",
                table: "Horses");
        }
    }
}
