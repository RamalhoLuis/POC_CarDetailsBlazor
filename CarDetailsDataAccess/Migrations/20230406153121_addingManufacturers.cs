using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDetailsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingManufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarsDb_ManufacturerId",
                table: "CarsDb",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDb_ManufacturersDb_ManufacturerId",
                table: "CarsDb",
                column: "ManufacturerId",
                principalTable: "ManufacturersDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsDb_ManufacturersDb_ManufacturerId",
                table: "CarsDb");

            migrationBuilder.DropIndex(
                name: "IX_CarsDb_ManufacturerId",
                table: "CarsDb");
        }
    }
}
