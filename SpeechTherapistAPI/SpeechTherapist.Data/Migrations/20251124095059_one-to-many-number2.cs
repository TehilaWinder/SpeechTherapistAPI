using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechTherapist.Data.Migrations
{
    /// <inheritdoc />
    public partial class onetomanynumber2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientCode",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "TreatmentCode",
                table: "appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientCode",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentCode",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
