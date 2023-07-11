using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1.Migrations
{
    /// <inheritdoc />
    public partial class Journey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirlineID",
                table: "Journeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Journeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_AirlineID",
                table: "Journeys",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_FlightID",
                table: "Journeys",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_AirlineTable_AirlineID",
                table: "Journeys",
                column: "AirlineID",
                principalTable: "AirlineTable",
                principalColumn: "Sno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Flight_FlightID",
                table: "Journeys",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_AirlineTable_AirlineID",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Flight_FlightID",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_AirlineID",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_FlightID",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "AirlineID",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Journeys");
        }
    }
}
