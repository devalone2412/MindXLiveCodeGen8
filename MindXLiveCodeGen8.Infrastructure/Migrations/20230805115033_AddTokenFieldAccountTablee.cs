using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindXLiveCodeGen8.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenFieldAccountTablee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Account");
        }
    }
}
