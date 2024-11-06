using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Participants");
        }
    }
}
