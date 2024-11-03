using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorSpecialityIcd10dotnet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icd10",
                columns: table => new
                {
                    id_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    id_int = table.Column<int>(type: "integer", nullable: false),
                    root_id_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    root_id_int = table.Column<int>(type: "integer", nullable: true),
                    REC_CODE = table.Column<string>(type: "text", nullable: false),
                    MKB_CODE = table.Column<string>(type: "text", nullable: false),
                    MKB_NAME = table.Column<string>(type: "text", nullable: false),
                    ID_PARENT = table.Column<string>(type: "text", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icd10", x => x.id_guid);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    speciality_id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialities_speciality_id",
                        column: x => x.speciality_id,
                        principalTable: "Specialities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    anamnesis = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    complaints = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    treatment = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    conclusion = table.Column<int>(type: "integer", nullable: false),
                    next_visit_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    base_inspection_id = table.Column<Guid>(type: "uuid", nullable: true),
                    previous_inspection_id = table.Column<Guid>(type: "uuid", nullable: true),
                    doctor_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inspections_Doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_speciality_id",
                table: "Doctors",
                column: "speciality_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_doctor_id",
                table: "Inspections",
                column: "doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Icd10");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialities");
        }
    }
}
