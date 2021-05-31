using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAPI.Migrations
{
    public partial class CarTrainCarmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainCars_CarId",
                table: "TrainCars");

            migrationBuilder.DropColumn(
                name: "TrainCarId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_TrainCars_CarId",
                table: "TrainCars",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainCars_CarId",
                table: "TrainCars");

            migrationBuilder.AddColumn<int>(
                name: "TrainCarId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainCars_CarId",
                table: "TrainCars",
                column: "CarId",
                unique: true);
        }
    }
}
