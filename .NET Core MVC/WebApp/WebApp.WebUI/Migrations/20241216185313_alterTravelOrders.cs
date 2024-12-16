using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class alterTravelOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelOrders_tCars_CarsId",
                table: "TravelOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelOrders_tEmployee_EmployeeId",
                table: "TravelOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelOrders",
                table: "TravelOrders");

            migrationBuilder.RenameTable(
                name: "TravelOrders",
                newName: "tTravelOrders");

            migrationBuilder.RenameIndex(
                name: "IX_TravelOrders_EmployeeId",
                table: "tTravelOrders",
                newName: "IX_tTravelOrders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelOrders_CarsId",
                table: "tTravelOrders",
                newName: "IX_tTravelOrders_CarsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tTravelOrders",
                table: "tTravelOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tTravelOrders_tCars_CarsId",
                table: "tTravelOrders",
                column: "CarsId",
                principalTable: "tCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tTravelOrders_tEmployee_EmployeeId",
                table: "tTravelOrders",
                column: "EmployeeId",
                principalTable: "tEmployee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tTravelOrders_tCars_CarsId",
                table: "tTravelOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tTravelOrders_tEmployee_EmployeeId",
                table: "tTravelOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tTravelOrders",
                table: "tTravelOrders");

            migrationBuilder.RenameTable(
                name: "tTravelOrders",
                newName: "TravelOrders");

            migrationBuilder.RenameIndex(
                name: "IX_tTravelOrders_EmployeeId",
                table: "TravelOrders",
                newName: "IX_TravelOrders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_tTravelOrders_CarsId",
                table: "TravelOrders",
                newName: "IX_TravelOrders_CarsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelOrders",
                table: "TravelOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelOrders_tCars_CarsId",
                table: "TravelOrders",
                column: "CarsId",
                principalTable: "tCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelOrders_tEmployee_EmployeeId",
                table: "TravelOrders",
                column: "EmployeeId",
                principalTable: "tEmployee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
