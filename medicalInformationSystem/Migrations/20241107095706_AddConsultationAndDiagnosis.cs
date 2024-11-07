using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultationAndDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Patients_PatientId",
                table: "Inspections");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Inspections",
                newName: "patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_PatientId",
                table: "Inspections",
                newName: "IX_Inspections_patient_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "patient_id",
                table: "Inspections",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    inspection_id = table.Column<Guid>(type: "uuid", nullable: false),
                    speciality_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultation_Inspections_inspection_id",
                        column: x => x.inspection_id,
                        principalTable: "Inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultation_Specialities_speciality_id",
                        column: x => x.speciality_id,
                        principalTable: "Specialities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    diagnosis_type = table.Column<int>(type: "integer", nullable: false),
                    diagnosis_id = table.Column<Guid>(type: "uuid", nullable: false),
                    inspection_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Inspections_inspection_id",
                        column: x => x.inspection_id,
                        principalTable: "Inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_inspection_id",
                table: "Consultation",
                column: "inspection_id");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_speciality_id",
                table: "Consultation",
                column: "speciality_id");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_inspection_id",
                table: "Diagnosis",
                column: "inspection_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Patients_patient_id",
                table: "Inspections",
                column: "patient_id",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Patients_patient_id",
                table: "Inspections");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Inspections",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_patient_id",
                table: "Inspections",
                newName: "IX_Inspections_PatientId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Inspections",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Patients_PatientId",
                table: "Inspections",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "id");
        }
    }
}
