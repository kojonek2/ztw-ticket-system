using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAPI.Migrations
{
    public partial class PlaceReservationaddrelationtrainCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainCarsId",
                table: "PlaceReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations",
                column: "TrainCarsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReservations_TrainCars_TrainCarsId",
                table: "PlaceReservations",
                column: "TrainCarsId",
                principalTable: "TrainCars",
                principalColumn: "TrainCarsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReservations_TrainCars_TrainCarsId",
                table: "PlaceReservations");

            migrationBuilder.DropIndex(
                name: "IX_PlaceReservations_TrainCarsId",
                table: "PlaceReservations");

            migrationBuilder.DropColumn(
                name: "TrainCarsId",
                table: "PlaceReservations");
        }
    }
}
