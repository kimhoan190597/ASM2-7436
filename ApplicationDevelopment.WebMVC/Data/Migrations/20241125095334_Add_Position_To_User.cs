using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.WebMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Position_To_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Users");
        }
    }
}
