using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechTherapist.Data.Migrations
{
    /// <inheritdoc />
    public partial class onetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientsPatientCode",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentsTreatmentCode",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientsPatientCode",
                table: "appointments",
                column: "PatientsPatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_TreatmentsTreatmentCode",
                table: "appointments",
                column: "TreatmentsTreatmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientsPatientCode",
                table: "appointments",
                column: "PatientsPatientCode",
                principalTable: "patients",
                principalColumn: "PatientCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_treatments_TreatmentsTreatmentCode",
                table: "appointments",
                column: "TreatmentsTreatmentCode",
                principalTable: "treatments",
                principalColumn: "TreatmentCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientsPatientCode",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_treatments_TreatmentsTreatmentCode",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PatientsPatientCode",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_TreatmentsTreatmentCode",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PatientsPatientCode",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "TreatmentsTreatmentCode",
                table: "appointments");
        }
    }
}
