using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_passengers",
                table: "passengers");

            migrationBuilder.RenameTable(
                name: "passengers",
                newName: "Passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Passenger_Id");

            migrationBuilder.CreateTable(
                name: "StationMasters",
                columns: table => new
                {
                    stationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationCode = table.Column<int>(type: "int", nullable: false),
                    stationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stationDivision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationMasters", x => x.stationId);
                });

            migrationBuilder.CreateTable(
                name: "TrainMasters",
                columns: table => new
                {
                    trainNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    routeId = table.Column<int>(type: "int", nullable: false),
                    trainCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainMasters", x => x.trainNumber);
                    table.ForeignKey(
                        name: "FK_TrainMasters_StationMasters_routeId",
                        column: x => x.routeId,
                        principalTable: "StationMasters",
                        principalColumn: "stationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainMasters_routeId",
                table: "TrainMasters",
                column: "routeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainMasters");

            migrationBuilder.DropTable(
                name: "StationMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_passengers",
                table: "passengers",
                column: "Passenger_Id");
        }
    }
}
