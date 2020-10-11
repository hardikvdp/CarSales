using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSales.Data.Migrations
{
    public partial class InitialRelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Engine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Doors = table.Column<int>(nullable: false),
                    Wheels = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    BodyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "Id", "BodyTypeName" },
                values: new object[,]
                {
                    { 1, "HATCHBACK" },
                    { 2, "SEDAN" },
                    { 3, "UTE" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "VehicleTypeName" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Boat" },
                    { 3, "Bike" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyTypeId", "Created", "Doors", "Engine", "Make", "Model", "Modified", "Price", "VehicleTypeId", "Wheels" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 10, 11, 22, 38, 11, 395, DateTimeKind.Local).AddTicks(9515), 4, "AUTO", "Toyota", "Camry", null, 25000m, 1, 4 },
                    { 2, 1, new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(828), 4, "AUTO", "Toyota", "Corolla", null, 15000m, 1, 4 },
                    { 3, 3, new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(894), 2, "AUTO", "Toyota", "Hilux", null, 35000m, 1, 4 },
                    { 4, 3, new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(901), 2, "AUTO", "Toyota", "HiAce", null, 30000m, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyTypeId",
                table: "Cars",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicleTypeId",
                table: "Cars",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
