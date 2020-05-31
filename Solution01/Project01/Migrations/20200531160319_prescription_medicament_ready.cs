using Microsoft.EntityFrameworkCore.Migrations;

namespace Project01.Migrations
{
    public partial class prescription_medicament_ready : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Prescription_Medicament",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dose",
                table: "Prescription_Medicament",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Prescription",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "Dose",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Prescription");
        }
    }
}
