using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class RMScomplaints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "complaints",
                columns: table => new
                {
                    complaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    complaintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complaintType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complaintDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complaints", x => x.complaintId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "complaints");
        }
    }
}
