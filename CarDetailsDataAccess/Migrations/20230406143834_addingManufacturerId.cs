using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDetailsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingManufacturerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "CarsDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "CarsDb");
        }
    }
}
