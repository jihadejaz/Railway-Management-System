using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "citiesAndStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citiesAndStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passengerBooking",
                columns: table => new
                {
                    PNR_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    passengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalPassengers = table.Column<int>(type: "int", nullable: false),
                    dateOfTravel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trainCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trainNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengerBooking", x => x.PNR_no);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remember_Me = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_Id);
                });

            migrationBuilder.CreateTable(
                name: "StationMasters",
                columns: table => new
                {
                    stationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    departureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    compartmentNo = table.Column<int>(type: "int", nullable: false),
                    trainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    routeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trainCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainMasters", x => x.trainNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citiesAndStates");

            migrationBuilder.DropTable(
                name: "passengerBooking");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "StationMasters");

            migrationBuilder.DropTable(
                name: "TrainMasters");
        }
    }
}
