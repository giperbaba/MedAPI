using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixIcd10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_PARENT",
                table: "Icd10");

            migrationBuilder.DropColumn(
                name: "root_id_int",
                table: "Icd10");

            migrationBuilder.RenameColumn(
                name: "root_id_guid",
                table: "Icd10",
                newName: "id_parent_guid");

            migrationBuilder.AddColumn<int>(
                name: "ACTUAL",
                table: "Icd10",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_parent_int",
                table: "Icd10",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACTUAL",
                table: "Icd10");

            migrationBuilder.DropColumn(
                name: "id_parent_int",
                table: "Icd10");

            migrationBuilder.RenameColumn(
                name: "id_parent_guid",
                table: "Icd10",
                newName: "root_id_guid");

            migrationBuilder.AddColumn<string>(
                name: "ID_PARENT",
                table: "Icd10",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "root_id_int",
                table: "Icd10",
                type: "integer",
                nullable: true);
        }
    }
}
