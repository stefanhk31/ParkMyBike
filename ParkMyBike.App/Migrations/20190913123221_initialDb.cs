using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordinatesId = table.Column<int>(nullable: false),
                    NumberOfRacks = table.Column<int>(nullable: false),
                    LocationDescription = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    RackType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeRacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BikeRacks",
                columns: new[] { "Id", "CoordinatesId", "LocationDescription", "NumberOfRacks", "RackType", "Status" },
                values: new object[] { 1, 1, "My Home", 1, 3, 0 });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 1, 36.014081300000001, -83.956911899999994 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeRacks");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
