using Microsoft.EntityFrameworkCore.Migrations;

namespace UnlockMe.Data.Migrations
{
    public partial class AddGenderProfilePic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImagePath",
                table: "AspNetUsers",
                newName: "ProfilePicture");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "AspNetUsers",
                newName: "ProfileImagePath");
        }
    }
}
