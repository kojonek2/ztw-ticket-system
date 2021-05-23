using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAPI.Migrations
{
    public partial class CarGraphiconetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Graphics_GraphicId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_GraphicId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GraphicId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Graphics_CarId",
                table: "Graphics",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graphics_Cars_CarId",
                table: "Graphics",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graphics_Cars_CarId",
                table: "Graphics");

            migrationBuilder.DropIndex(
                name: "IX_Graphics_CarId",
                table: "Graphics");

            migrationBuilder.AddColumn<int>(
                name: "GraphicId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GraphicId",
                table: "Cars",
                column: "GraphicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Graphics_GraphicId",
                table: "Cars",
                column: "GraphicId",
                principalTable: "Graphics",
                principalColumn: "GraphicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
