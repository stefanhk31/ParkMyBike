using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkMyBike.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BikeRacks",
                columns: new[] { "Id", "Address", "LocationDescription", "NumberOfRacks", "RackType", "Status" },
                values: new object[] { 1, "2217 North Broadway, Knoxville, TN 37917", "Kroger", 2, "Hitch", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BikeRacks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
