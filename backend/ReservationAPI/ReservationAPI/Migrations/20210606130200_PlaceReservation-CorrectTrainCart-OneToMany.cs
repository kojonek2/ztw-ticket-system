using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAPI.Migrations
{
    public partial class PlaceReservationCorrectTrainCartOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations",
                column: "TrainCarsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations",
                column: "TrainCarsId",
                unique: true);
        }
    }
}
