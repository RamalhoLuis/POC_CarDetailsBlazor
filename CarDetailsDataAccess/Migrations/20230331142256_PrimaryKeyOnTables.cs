using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDetailsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryKeyOnTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Displacement = table.Column<double>(type: "float", nullable: false),
                    Cylinders = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Highway = table.Column<int>(type: "int", nullable: false),
                    Combined = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JointInfoDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Displacement = table.Column<double>(type: "float", nullable: false),
                    Cylinders = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Highway = table.Column<int>(type: "int", nullable: false),
                    Combined = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JointInfoDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturersDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturersDb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsDb");

            migrationBuilder.DropTable(
                name: "JointInfoDb");

            migrationBuilder.DropTable(
                name: "ManufacturersDb");
        }
    }
}
