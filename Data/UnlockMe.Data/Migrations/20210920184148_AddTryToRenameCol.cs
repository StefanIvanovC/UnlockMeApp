using Microsoft.EntityFrameworkCore.Migrations;

namespace UnlockMe.Data.Migrations
{
    public partial class AddTryToRenameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Questions",
                newName: "QuestionAsk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionAsk",
                table: "Questions",
                newName: "Question");
        }
    }
}
