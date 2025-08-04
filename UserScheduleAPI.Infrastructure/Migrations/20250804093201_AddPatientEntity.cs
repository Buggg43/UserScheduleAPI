using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserScheduleAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientSpecialInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSpecialInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSpecialInfo_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSpecialInfo_SpecialInfos_SpecialInfoId",
                        column: x => x.SpecialInfoId,
                        principalTable: "SpecialInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientSpecialInfo_PatientId",
                table: "PatientSpecialInfo",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSpecialInfo_SpecialInfoId",
                table: "PatientSpecialInfo",
                column: "SpecialInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientSpecialInfo");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
