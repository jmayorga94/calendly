using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendly.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oficces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Oficces_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Oficces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Oficces",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ImageUrl", "IsAvailable", "LastModified", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("ae0bb628-9344-40d8-9753-61a9c5d46371"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://localhost/image/123-png", false, null, null, "Headquartes" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreationDate", "Date", "Description", "EndHour", "LastModified", "LastModifiedDate", "OfficeId", "StartHour" },
                values: new object[] { new Guid("f9954c4a-45f9-464f-a12c-6c76b25b2837"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 0, 24, 12, 310, DateTimeKind.Local).AddTicks(1983), new DateTime(2021, 4, 11, 0, 24, 12, 309, DateTimeKind.Local).AddTicks(2646), "Appointment at dentist", 2, null, null, new Guid("ae0bb628-9344-40d8-9753-61a9c5d46371"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OfficeId",
                table: "Appointments",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Oficces");
        }
    }
}
