using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindXLiveCodeGen8.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipAccountAndResume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Resume",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resume_AccountId",
                table: "Resume",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Account_AccountId",
                table: "Resume",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Account_AccountId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_AccountId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Resume");
        }
    }
}
