using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vl_dotnet_backend.Migrations
{
    /// <inheritdoc />
    public partial class ParkingLotsImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ParkingLots",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ParkingLots");
        }
    }
}
