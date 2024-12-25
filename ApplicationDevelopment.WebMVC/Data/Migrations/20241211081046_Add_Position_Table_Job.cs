using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.WebMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Position_Table_Job : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Postion",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Postion",
                table: "Jobs");
        }
    }
}
