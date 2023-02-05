using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Site.Migrations
{
    public partial class AddTranscTranslate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteName",
                table: "SiteNotes",
                newName: "Note");

            migrationBuilder.AddColumn<string>(
                name: "Transcription",
                table: "SiteNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Translate",
                table: "SiteNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb695f40-c3cb-42ed-8b73-8c2dce74367f", "AQAAAAEAACcQAAAAEDkoeXKzbe91dPytcgsr8vts0AllTzoCOaZ3SMoyNm21GzoFTXTeNt+S0cLevjE8xg==", "074fd3f3-8264-4c73-b504-f7beabfaefe1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transcription",
                table: "SiteNotes");

            migrationBuilder.DropColumn(
                name: "Translate",
                table: "SiteNotes");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "SiteNotes",
                newName: "NoteName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98308d5a-f1ad-45c5-a951-c19dd3272799", "AQAAAAEAACcQAAAAEPpHtpSipkZ7nsCeSwsj8LQk5CElrm8+BDdZMZF6csySDInoohyd3R8PxPL98HVKZw==", "9c656a51-9d84-4d99-ac92-c0617045657e" });
        }
    }
}
