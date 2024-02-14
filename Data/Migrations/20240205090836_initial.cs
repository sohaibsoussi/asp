using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_s7.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorsePrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horses");
        }
    }
}
