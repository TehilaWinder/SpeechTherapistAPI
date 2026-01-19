using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechTherapist.Data.Migrations
{
    /// <inheritdoc />
    public partial class addusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "patients");

            migrationBuilder.RenameColumn(
                name: "Rport",
                table: "patients",
                newName: "Report");

            migrationBuilder.AddColumn<int>(
                name: "SpeechTerapistSpeechTherapistCode",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCode",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCode1",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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
                    UserCode1 = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speechTerapists", x => x.SpeechTherapistCode);
                    table.ForeignKey(
                        name: "FK_speechTerapists_users_UserCode1",
                        column: x => x.UserCode1,
                        principalTable: "users",
                        principalColumn: "UserCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_SpeechTerapistSpeechTherapistCode",
                table: "patients",
                column: "SpeechTerapistSpeechTherapistCode");

            migrationBuilder.CreateIndex(
                name: "IX_patients_UserCode1",
                table: "patients",
                column: "UserCode1");

            migrationBuilder.CreateIndex(
                name: "IX_speechTerapists_UserCode1",
                table: "speechTerapists",
                column: "UserCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_speechTerapists_SpeechTerapistSpeechTherapistCode",
                table: "patients",
                column: "SpeechTerapistSpeechTherapistCode",
                principalTable: "speechTerapists",
                principalColumn: "SpeechTherapistCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_users_UserCode1",
                table: "patients",
                column: "UserCode1",
                principalTable: "users",
                principalColumn: "UserCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_speechTerapists_SpeechTerapistSpeechTherapistCode",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_users_UserCode1",
                table: "patients");

            migrationBuilder.DropTable(
                name: "speechTerapists");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_patients_SpeechTerapistSpeechTherapistCode",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_UserCode1",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "SpeechTerapistSpeechTherapistCode",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "UserCode1",
                table: "patients");

            migrationBuilder.RenameColumn(
                name: "Report",
                table: "patients",
                newName: "Rport");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
