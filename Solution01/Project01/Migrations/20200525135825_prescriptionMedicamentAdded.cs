using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project01.Migrations
{
    public partial class prescriptionMedicamentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Prescription",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 13, 43, 6, 227, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdPresctiption = table.Column<int>(nullable: false),
                    IdMedicament = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.IdPresctiption, x.IdMedicament });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 13, 43, 6, 227, DateTimeKind.Utc).AddTicks(8971),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
