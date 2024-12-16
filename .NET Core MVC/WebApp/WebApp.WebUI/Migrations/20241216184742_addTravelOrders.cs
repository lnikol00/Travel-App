using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class addTravelOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelOrders_tCars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "tCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelOrders_tEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelOrders_CarsId",
                table: "TravelOrders",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelOrders_EmployeeId",
                table: "TravelOrders",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelOrders");
        }
    }
}
