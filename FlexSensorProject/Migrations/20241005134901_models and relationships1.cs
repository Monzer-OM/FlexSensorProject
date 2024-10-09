using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexSensorProject.Migrations
{
    /// <inheritdoc />
    public partial class modelsandrelationships1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatintName",
                table: "Patients",
                newName: "PatientName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "Patients",
                newName: "PatintName");
        }
    }
}
