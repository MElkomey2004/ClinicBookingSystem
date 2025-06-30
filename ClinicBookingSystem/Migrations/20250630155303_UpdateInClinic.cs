using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_SpecialtyId",
                table: "Clinics",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Specialties_SpecialtyId",
                table: "Clinics",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Specialties_SpecialtyId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_SpecialtyId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Clinics");
        }
    }
}
