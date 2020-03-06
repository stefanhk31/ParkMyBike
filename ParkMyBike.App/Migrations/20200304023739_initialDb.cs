using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkMyBike.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeRacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfRacks = table.Column<int>(nullable: true),
                    Position_Latitude = table.Column<double>(nullable: true),
                    Position_Longitude = table.Column<double>(nullable: true),
                    LocationDescription = table.Column<string>(nullable: true),
                    RackType = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeRacks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeRacks");
        }
    }
}
