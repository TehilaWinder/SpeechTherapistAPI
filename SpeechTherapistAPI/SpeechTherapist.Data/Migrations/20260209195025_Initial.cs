using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechTherapist.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "treatments",
                columns: table => new
                {
                    TreatmentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinutes = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatments", x => x.TreatmentCode);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "speechTerapists",
                columns: table => new
                {
                    SpeechTherapistCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speechTerapists", x => x.SpeechTherapistCode);
                    table.ForeignKey(
                        name: "FK_speechTerapists_users_UserCode",
                        column: x => x.UserCode,
                        principalTable: "users",
                        principalColumn: "UserCode");
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<int>(type: "int", nullable: false),
                    SpeechTherapistCode = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SpeechTerapistSpeechTherapistCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientCode);
                    table.ForeignKey(
                        name: "FK_patients_speechTerapists_SpeechTerapistSpeechTherapistCode",
                        column: x => x.SpeechTerapistSpeechTherapistCode,
                        principalTable: "speechTerapists",
                        principalColumn: "SpeechTherapistCode");
                    table.ForeignKey(
                        name: "FK_patients_speechTerapists_SpeechTherapistCode",
                        column: x => x.SpeechTherapistCode,
                        principalTable: "speechTerapists",
                        principalColumn: "SpeechTherapistCode");
                    table.ForeignKey(
                        name: "FK_patients_users_UserCode",
                        column: x => x.UserCode,
                        principalTable: "users",
                        principalColumn: "UserCode");
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    AppointmentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PatientCode = table.Column<int>(type: "int", nullable: false),
                    TreatmentCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.AppointmentCode);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientCode",
                        column: x => x.PatientCode,
                        principalTable: "patients",
                        principalColumn: "PatientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_treatments_TreatmentCode",
                        column: x => x.TreatmentCode,
                        principalTable: "treatments",
                        principalColumn: "TreatmentCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    ReportCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientCode = table.Column<int>(type: "int", nullable: false),
                    SpeechTherapistCode = table.Column<int>(type: "int", nullable: false),
                    GoogleDocUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApprovedByTherapist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.ReportCode);
                    table.ForeignKey(
                        name: "FK_reports_patients_PatientCode",
                        column: x => x.PatientCode,
                        principalTable: "patients",
                        principalColumn: "PatientCode");
                    table.ForeignKey(
                        name: "FK_reports_speechTerapists_SpeechTherapistCode",
                        column: x => x.SpeechTherapistCode,
                        principalTable: "speechTerapists",
                        principalColumn: "SpeechTherapistCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientCode",
                table: "appointments",
                column: "PatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_TreatmentCode",
                table: "appointments",
                column: "TreatmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_patients_SpeechTerapistSpeechTherapistCode",
                table: "patients",
                column: "SpeechTerapistSpeechTherapistCode");

            migrationBuilder.CreateIndex(
                name: "IX_patients_SpeechTherapistCode",
                table: "patients",
                column: "SpeechTherapistCode");

            migrationBuilder.CreateIndex(
                name: "IX_patients_UserCode",
                table: "patients",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_reports_PatientCode",
                table: "reports",
                column: "PatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_reports_SpeechTherapistCode",
                table: "reports",
                column: "SpeechTherapistCode");

            migrationBuilder.CreateIndex(
                name: "IX_speechTerapists_UserCode",
                table: "speechTerapists",
                column: "UserCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "treatments");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "speechTerapists");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
