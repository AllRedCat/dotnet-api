using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vl_dotnet_backend.Migrations
{
    /// <inheritdoc />
    public partial class StoreOperationalScheduleAsJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationalSchedule");

            migrationBuilder.AddColumn<string>(
                name: "OperationalSchedule",
                table: "ParkingLots",
                type: "json",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationalSchedule",
                table: "ParkingLots");

            migrationBuilder.CreateTable(
                name: "OperationalSchedule",
                columns: table => new
                {
                    ParkingLotsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CloseTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationalSchedule", x => new { x.ParkingLotsId, x.Id });
                    table.ForeignKey(
                        name: "FK_OperationalSchedule_ParkingLots_ParkingLotsId",
                        column: x => x.ParkingLotsId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
